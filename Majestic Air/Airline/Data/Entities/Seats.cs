namespace Airline.Data.Entities
{
    public class Seats : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TicketClass Classe { get; set; } 

        public bool Available { get; set; }
        public User User { get; set; }
    }
}
