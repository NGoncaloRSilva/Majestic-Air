using System.ComponentModel.DataAnnotations;

namespace Airline.Data.Entities
{
    public class TicketClass : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ticket Class")]
        public string Class { get; set; }

        public User User { get; set; }
    }
}
