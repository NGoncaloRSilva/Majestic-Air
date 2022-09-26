using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Data.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Trip trip { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
    }
}
