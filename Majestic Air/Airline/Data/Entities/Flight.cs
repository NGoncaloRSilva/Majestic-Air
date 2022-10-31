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
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Day { get; set; }
        [Required]
        [Display(Name = "Airship")]
        public Airship AirshipName { get; set; }
        [Required]
        [Display(Name = "Price 1stClass")]
        public decimal Price1stClass { get; set; }
        [Required]
        [Display(Name = "Price Business")]
        public decimal PriceBusiness { get; set; }
        [Required]
        [Display(Name = "Price PremiumEconomy")]
        public decimal PricePremiumEconomy { get; set; }
        [Required]
        [Display(Name = "Price Economy")]
        public decimal PriceEconomy { get; set; }

        [Required]
        
        public Airports Origin { get; set; }
        [Required]
        public Airports Destination { get; set; }

        public int Stock => AirshipName.model.SumTickets;

        [Display(Name = "Is Available")]
        public bool Available => Stock != 0;

        public User User { get; set; }
    }
}
