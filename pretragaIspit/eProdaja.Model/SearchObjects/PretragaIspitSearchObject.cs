using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.SearchObjects
{
    public class PretragaIspitSearchObject:BaseSearchObject
    {
        public int VrstaProizvodaId { get; set; }
        public double minIznosPrometa { get; set; }
        public DateTime? periodOD { get; set; }
        public DateTime? periodDO { get; set; }
    }
}
