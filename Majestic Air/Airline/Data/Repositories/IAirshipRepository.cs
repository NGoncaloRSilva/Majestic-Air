using Airline.Data.Entities;
using System.Linq;

namespace Airline.Data.Repositories
{
    public interface IAirshipRepository : IGenericRepository<Airship>
    {
        public IQueryable GetAllWithUsers();
    }
}
