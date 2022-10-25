using System.ComponentModel.DataAnnotations;

namespace Airline.Data.Entities
{
    public class TicketClass
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Ticket Class")]
        public string Class { get; set; }

        public User User { get; set; }
    }
}
