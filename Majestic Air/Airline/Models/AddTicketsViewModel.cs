using Airline.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airline.Models
{
    public class AddTicketsViewModel
    {
        

        [Display(Name = "Tickets")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a flight.")]
        public int FlightId { get; set; }


        [Range(0.0001, double.MaxValue, ErrorMessage = "The quantity must be a positive number.")]
        public double Quantity { get; set; }

        public IEnumerable<SelectListItem> Tickets { get; set; }
    }
}
