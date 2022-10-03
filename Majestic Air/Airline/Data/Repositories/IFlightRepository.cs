using Airline.Data.Entities;
using System.Linq;

namespace Airline.Data.Repositories
{
    public interface IFlightRepository : IGenericRepository<Flight>
    {
        public IQueryable GetAllWithUsers();
    }
}
