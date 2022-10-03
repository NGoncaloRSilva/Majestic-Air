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
        public string Class { get; set; }
        public User User { get; set; }
       
    }
}
