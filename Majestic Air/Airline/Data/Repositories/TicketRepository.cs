using Airline.Data.Entities;
using Microsoft.EntityFrameworkCore;
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
    }
}
