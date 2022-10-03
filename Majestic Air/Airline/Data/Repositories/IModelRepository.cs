using Airline.Data.Entities;
using System.Linq;

namespace Airline.Data.Repositories
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        public IQueryable GetAllWithUsers();
    }
}
