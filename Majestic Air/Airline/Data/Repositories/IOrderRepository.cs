using Airline.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Data.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrderAsync(string userName);

        Task<IQueryable<Order>> GetOrderByUserNameAsync(string userName);

        Task<IQueryable<OrderDetailTemp>> GetDetailsTempsAsync(string userName);

        Task<IQueryable<OrderDetailTemp>> GetDetailsTempsByUserNameAsync(string userName);
    }
}
