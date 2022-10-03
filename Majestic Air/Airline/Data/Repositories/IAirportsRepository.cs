using Airline.Data.Entities;
using System.Linq;

namespace Airline.Data.Repositories
{
    public interface IAirportsRepository : IGenericRepository<Airports>
    {
        public IQueryable GetAllWithUsers();
    }
}
