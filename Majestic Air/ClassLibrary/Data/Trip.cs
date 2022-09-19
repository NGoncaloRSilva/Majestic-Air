using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public DateTime Hour { get; set; }
        public Airship AirshipName { get; set; }
        public double Price1stClass { get; set; }
        public double PriceBusiness { get; set; }
        public double PricePremiumEconomy { get; set; }
        public double PriceEconomy { get; set; }
        //public int IdOrigin { get; set; }
        //public int IdDestination { get; set; }
        public Location Origin { get; set; }
        public Location Destination { get; set; }
    }
}
