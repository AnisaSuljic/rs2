using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace eProdaja.Services
{
    public class IzlaziService : BaseService<Model.Izlazi, Database.Izlazi, PretragaIspitSearchObject>
    {
        public IzlaziService(eProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Izlazi> Get(PretragaIspitSearchObject search = null)
        {
            var lista = Context.Izlazis.Include(x=>x.Korisnik).Include(x=>x.IzlazStavkes).ThenInclude(x=>x.Proizvod).ToList();

            if (search != null)
            {
                if(search.periodDO != null && search.periodDO != null && search.VrstaProizvodaId != 0)
                {
                   lista = lista.Where(x => x.Datum >= search.periodOD && x.Datum <= search.periodDO
                    && x.IzlazStavkes.Sum(x => x.Kolicina * x.Cijena * (x.Popust != 0 ? x.Popust : 1)) > decimal.Parse(search.minIznosPrometa.ToString())).ToList()
                    .SelectMany(x => x.IzlazStavkes).Where(x => x.Proizvod.VrstaId == search.VrstaProizvodaId).Select(x => x.Izlaz).Distinct().ToList();


                }
            }

            return Mapper.Map<List<Model.Izlazi>>(lista);
        }
    }
}
