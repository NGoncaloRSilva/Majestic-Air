using Airline.Data.Entities;
using Airline.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
