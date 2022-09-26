using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Data.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Tickets1stClass { get; set; }
        public int TicketsBusiness { get; set; }
        public int TicketsPremiumEconomy { get; set; }
        public int TicketsEconomy { get; set; }

        public int SumTickets
        {
            get
            {
                return Tickets1stClass + TicketsBusiness + TicketsPremiumEconomy + TicketsEconomy;
            }

        }
    }
}
