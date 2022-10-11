using Airline.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Airline.Data.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        private readonly DataContext _context;
        public TicketRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Tickets.Include(p => p.User);
        }

        public IEnumerable<SelectListItem> GetComboTickets()
        {
            var list = _context.Tickets.Select(p => new SelectListItem
            {
                Text = $" {p.Code} {p.FlightName.Origin.Name} to {p.FlightName.Destination.Name} {p.FlightName.Day.ToShortDateString()} { p.Class} ",
                Value = p.Id.ToString(),

            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a ticket...)",
                Value = "0",
            });

            return list;


        }
    }
}
