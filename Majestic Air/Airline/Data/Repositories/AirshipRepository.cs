using Airline.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Airline.Data.Repositories
{
    public class AirshipRepository : GenericRepository<Airship>, IAirshipRepository
    {
        private readonly DataContext _context;

        public AirshipRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Airships.Include(p => p.User);
        }
    }
}
