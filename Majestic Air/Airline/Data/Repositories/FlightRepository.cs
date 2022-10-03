using Airline.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Airline.Data.Repositories
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        private readonly DataContext _context;
        public FlightRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Flights.Include(p => p.User);
        }
    }
}
