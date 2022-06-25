using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.Database
{
    public class PretragaIspit
    {
        public int PretragaIspitId { get; set; }
        public int VrstaProizvodaId { get; set; }
        public double minIznosPrometa { get; set; }
        public DateTime periodOD { get; set; }
        public DateTime periodDO { get; set; }
        public double iznosPrometa { get; set; }
        public virtual Korisnici korisnik { get; set; }
        public virtual VrsteProizvodum vrstaProizvoda { get; set; }



    }
}
