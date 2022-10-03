using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Data.Entities
{
    public class Flight : IEntity
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        [Display(Name = "Airship")]
        public Airship AirshipName { get; set; }
        [Required]
        [Display(Name = "Price 1stClass")]
        public double Price1stClass { get; set; }
        [Required]
        [Display(Name = "Price Business")]
        public double PriceBusiness { get; set; }
        [Required]
        [Display(Name = "Price PremiumEconomy")]
        public double PricePremiumEconomy { get; set; }
        [Required]
        [Display(Name = "Price Economy")]
        public double PriceEconomy { get; set; }
        //public int IdOrigin { get; set; }
        //public int IdDestination { get; set; }
        [Required]
        [Display(Name = "Origin")]
        public Airports Origin { get; set; }
        [Required]
        [Display(Name = "Destination")]
        public Airports Destination { get; set; }

        public User User { get; set; }
    }
}
