using Airline.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airline.Models
{
    public class FlightViewModel 
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Day { get; set; }
        [Display(Name = "Airship")]
        public Airship AirshipName { get; set; }
        [Display(Name = "Price 1stClass")]
        public double Price1stClass { get; set; }
        [Display(Name = "Price Business")]
        public double PriceBusiness { get; set; }
        [Display(Name = "Price PremiumEconomy")]
        public double PricePremiumEconomy { get; set; }
        [Display(Name = "Price Economy")]
        public double PriceEconomy { get; set; }

        
        public Airports Origin { get; set; }
        
        public Airports Destination { get; set; }

        public User User { get; set; }



        public bool Available { get; set; }


        


        [Required]
        [Display(Name = "Airship")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select an airship.")]
        public int AirshipId { get; set; }

        
        [Display(Name = "Destination")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Destination.")]
        public int DestinationId { get; set; }


        [Display(Name = "Origin")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select an Origin.")]
        public int OriginId { get; set; }

        //[Display(Name = "Flight Number")]
        //[Range(1, int.MaxValue, ErrorMessage = "You must select a Flight Number.")]
        //public int NumberId { get; set; }




        public IEnumerable<SelectListItem> ListAirports { get; set; }

        public IEnumerable<SelectListItem> ListAirships { get; set; }

        public IEnumerable<SelectListItem> ListNumbers { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
