using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Data.Entities
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; } 
        [Required]
        [Display(Name = "Flight")]
        public Flight FlightName { get; set; }

        [Required]
        public Seats Seat { get; set; }



        //[Required]
        //public TicketClass Class { get; set; }

        [Range(0.0001, double.MaxValue, ErrorMessage = "The quantity must be a positive number.")]
        //public double Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }
        public User User { get; set; }
       
    }
}
