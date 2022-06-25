using AutoMapper;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Korisnici, Model.Korisnici>()
                .ForMember(x=>x.Promet, m=>m.MapFrom(src=>src.Izlazis.Sum(x=>x.IzlazStavkes.Sum(x=>x.Kolicina*x.Cijena*(x.Popust!=0?x.Popust:1)))))
                .ReverseMap();

            CreateMap<Database.KorisniciUloge, Model.KorisniciUloge>().ReverseMap();
            CreateMap<Database.Uloge, Model.Uloge>().ReverseMap();

            CreateMap<KorisniciInsertRequest, Database.Korisnici>().ReverseMap();
            CreateMap<KorisniciUpdateRequest, Database.Korisnici>().ReverseMap();

            CreateMap<Database.Proizvodi, Model.Proizvodi>().ReverseMap();
            CreateMap<Database.JediniceMjere, Model.JediniceMjere>().ReverseMap();

            CreateMap<JediniceMjereUpsertRequest, Database.JediniceMjere>().ReverseMap();

            CreateMap<ProizvodiInsertRequest, Database.Proizvodi>().ReverseMap();
            CreateMap<ProizvodiUpdateRequest, Database.Proizvodi>().ReverseMap();


            CreateMap<Database.VrsteProizvodum, Model.VrsteProizvodum>().ReverseMap();
            CreateMap<VrsteProizvodumUpsertRequest, Database.VrsteProizvodum>().ReverseMap();
            CreateMap<Database.IzlazStavke,Model.IzlazStavka>().ReverseMap();
            CreateMap<Database.Izlazi, Model.Izlazi>()
                .ForMember(x => x.Ime, src => src.MapFrom(x => x.Korisnik.Ime+" "+x.Korisnik.Prezime))
                .ForMember(x=>x.Promet,src=>src.MapFrom(x=>x.IzlazStavkes.Sum(x=>x.Kolicina*x.Cijena* (x.Popust != 0 ? x.Popust : 1))))
                .ReverseMap();


            CreateMap<Database.Narudzbe, Model.Narudzbe>().ReverseMap();
            CreateMap<NarudzbaInsertRequest, Database.Narudzbe>().ReverseMap();
            CreateMap<NarudzbaUpdateRequest, Database.Narudzbe>().ReverseMap();
        }
    }
}
