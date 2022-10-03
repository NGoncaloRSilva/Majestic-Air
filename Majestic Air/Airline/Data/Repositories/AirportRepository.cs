using Airline.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Airline.Data.Repositories
{
    public class AirportRepository : GenericRepository<Airports>, IAirportsRepository
    {
        private readonly DataContext _context;

        public AirportRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Airports.Include(p => p.User);
        }
    }
}
