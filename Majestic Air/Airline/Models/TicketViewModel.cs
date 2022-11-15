using Airline.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airline.Models
{
    public class TicketViewModel 
    {
        public int Id { get; set; }
        public string Code { get; set; }

        [Display(Name = "Flight")]
        public Flight FlightName { get; set; }

        public TicketClass Class { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        public User User { get; set; }






        [Display(Name = "Available Flights")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a flight.")]
        public int FlightId { get; set; }

        [Display(Name = "Class")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a class.")]
        public int ClassId { get; set; }


        

        public IEnumerable<SelectListItem> Flights { get; set; }

        public IEnumerable<SelectListItem> Classes { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
