using Airline.Data.Entities;
using System.Linq;

namespace Airline.Data.Repositories
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        public IQueryable GetAllWithUsers();
    }
}
