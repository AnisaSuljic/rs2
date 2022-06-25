using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public class Izlazi
    {
        public int IzlazId { get; set; }
        public string BrojRacuna { get; set; }
        public DateTime Datum { get; set; }
        public int KorisnikId { get; set; }
        public string KorisnikImePrezime { get; set; }
        public bool Zakljucen { get; set; }
        public decimal IznosBezPdv { get; set; }
        public decimal IznosSaPdv { get; set; }
        public int? NarudzbaId { get; set; }
        public int SkladisteId { get; set; }
        public decimal Promet { get; set; }
        public string Ime { get; set; }

        public virtual Korisnici Korisnik { get; set; }
        //public virtual Narudzbe Narudzba { get; set; }
        public virtual ICollection<IzlazStavka> IzlazStavkes { get; set; }
    }
}
