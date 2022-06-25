using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.Database
{
    public partial class eProdajaContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //jeidnice mjere
            modelBuilder.Entity<JediniceMjere>().HasData(new eProdaja.Services.Database.JediniceMjere
            {
                JedinicaMjereId = 1,
                Naziv="kom"
            });            
            modelBuilder.Entity<JediniceMjere>().HasData(new eProdaja.Services.Database.JediniceMjere
            {
                JedinicaMjereId = 2,
                Naziv="kg"
            });
            modelBuilder.Entity<JediniceMjere>().HasData(new eProdaja.Services.Database.JediniceMjere
            {
                JedinicaMjereId = 3,
                Naziv="litar"
            });
        }
    }
}
