using AutoMapper;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using eProdaja.Model;

namespace eProdaja.Services
{
    public class KorisniciService : BaseCRUDService<Model.Korisnici, Database.Korisnici, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>, IKorisniciService
    {
        public KorisniciService(eProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public List<Model.Korisnici> KorisniciFilterPretraga(PretragaIspitSearchObject search)
        {
            var listaKorisnika = Context.Korisnicis.Include(x => x.Izlazis).ThenInclude(x => x.IzlazStavkes).ThenInclude(x => x.Proizvod).ToList();

            if (search != null)
            {
                if (search.periodDO != null && search.periodDO != null && search.VrstaProizvodaId != 0)
                {
                    //var x = listaKorisnika.SelectMany(x => x.Izlazis.Where(y => y.Datum >= search.periodOD && y.Datum <= search.periodDO)).ToList();

                    //listaKorisnika = listaKorisnika.SelectMany(x => x.Izlazis.Where(y => y.Datum >= search.periodOD && y.Datum <= search.periodDO)).ToList()
                    //    .SelectMany(y=>y.IzlazStavkes.Where(x => x.Proizvod.VrstaId == search.VrstaProizvodaId).Select(x => x.Izlaz).Distinct().ToList())
                    //    .Where(y=> y.IzlazStavkes.Sum(z => z.Kolicina * z.Cijena * (z.Popust != 0 ? z.Popust : 1)) > decimal.Parse(search.minIznosPrometa.ToString())).ToList()
                    //    .Select(x => x.Korisnik).Distinct().ToList();

                    //listaKorisnika=listaKorisnika.Where(x=>x.Izlazis.Where(y=>y.Datum>=search.periodOD && y.Datum<=search.periodDO)

                    var a = Context.Izlazis.Where(y => (y.Datum >= search.periodOD && y.Datum <= search.periodDO) 
                    && (y.IzlazStavkes.Sum(s=>s.Kolicina*s.Cijena*(s.Popust!=0?s.Popust:1))>decimal.Parse(search.minIznosPrometa.ToString()))
                    && (y.IzlazStavkes.Where(k=>k.Proizvod.VrstaId==search.VrstaProizvodaId).Count()>0)).Select(x => x.Korisnik).Distinct();

                    var mapped = Mapper.Map<List<Model.Korisnici>>(a);
                    foreach (var item in mapped)
                    {
                        var ghjk = Context.Izlazis.Where(x => x.KorisnikId == item.KorisnikId && x.Datum >= search.periodOD);
                        List<Database.IzlazStavke> listaneka = new List<Database.IzlazStavke>() ;
                        foreach (var item1 in ghjk)
                        {
                            //var obj = item1.IzlazStavkes.Where(x=>x.IzlazId==1).Select(x=>x)
                           
                        }
                    }



                    var lista = listaKorisnika.SelectMany(x => x.Izlazis.Where(u => u.Datum >= search.periodOD && u.Datum <= search.periodDO)).ToList();

                    lista = lista.SelectMany(x => x.IzlazStavkes.Where(x => x.Proizvod.VrstaId == search.VrstaProizvodaId)).Select(x=>x.Izlaz).Distinct().ToList();

                    lista = lista.Where(x => x.IzlazStavkes.Sum(x => x.Kolicina * x.Cijena * (x.Popust != 0 ? x.Popust : 1)) > decimal.Parse(search.minIznosPrometa.ToString())).ToList();


                    var kor = lista.Select(x => x.Korisnik).Distinct().ToList();

                    //var lista2 = lista.SelectMany(x => x.IzlazStavkes.Where(x => x.Proizvod.VrstaId == search.VrstaProizvodaId)).ToList();

                    //var lista1 = listaKorisnika.SelectMany(x => x.Izlazis.Where(u => u.Datum >= search.periodOD && u.Datum <= search.periodDO)).Select(x => x.Korisnik).Distinct().ToList();

                    //final 
                    listaKorisnika = kor;
                }
            }
            return Mapper.Map<List<Model.Korisnici>>(listaKorisnika);
        }
        
        public override Model.Korisnici Insert(KorisniciInsertRequest insert)
        {

            if (insert.Password != insert.PasswordPotvrda)
            {
                throw new UserException("Password and confirmation must be the same");
            }

            var entity = base.Insert(insert);

            
            foreach(var ulogaId in insert.UlogeIdList)
            {
                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
                korisniciUloge.UlogaId = ulogaId;
                korisniciUloge.KorisnikId = entity.KorisnikId;
                korisniciUloge.DatumIzmjene = DateTime.Now;

                Context.KorisniciUloges.Add(korisniciUloge);
            }

            Context.SaveChanges();

            return entity;
        }

        public override void BeforeInsert(KorisniciInsertRequest insert, Database.Korisnici entity)
        {
            var salt = GenerateSalt();
            entity.LozinkaSalt = salt;
            entity.LozinkaHash = GenerateHash(salt, insert.Password);
            base.BeforeInsert(insert, entity);
        }


        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public override IQueryable<Database.Korisnici> AddFilter(IQueryable<Database.Korisnici> query, KorisniciSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.KorisnickoIme))
            {
                filteredQuery = filteredQuery.Where(x => x.KorisnickoIme == search.KorisnickoIme);
            }

            if (!string.IsNullOrWhiteSpace(search?.NameFTS))
            {
                filteredQuery = filteredQuery.Where(x => x.KorisnickoIme.Contains(search.NameFTS) 
                    || x.Ime.Contains(search.NameFTS)
                    || x.Prezime.Contains(search.NameFTS));
            }

            return filteredQuery;
        }

        public override IQueryable<Database.Korisnici> AddInclude(IQueryable<Database.Korisnici> query, KorisniciSearchObject search = null)
        {
            if (search?.IncludeRoles == true)
            {
                 query = query.Include("KorisniciUloges.Uloga");
            }
            return query;
        }

        public Model.Korisnici Login(string username, string password)
        {
            var entity = Context.Korisnicis.Include("KorisniciUloges.Uloga").FirstOrDefault(x => x.KorisnickoIme == username);
            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if (hash != entity.LozinkaHash)
            {
                return null;
            }

            return Mapper.Map<Model.Korisnici>(entity);
        }

    }
}
