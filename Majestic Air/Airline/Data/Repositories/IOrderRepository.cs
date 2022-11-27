using Airline.Data.Entities;
using Airline.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Data.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrderAsync(string userName);

        Task<IQueryable<OrderDetailTemp>> GetDetailsTempsAsync(string userName);

        Task AddItemToOrderAsync(TicketViewModel model, string userName);



        Task<bool> ConfirmOrderAsync(string username);


        //Task ModifyOrderDetailTempQuantity(int id, double quantity);

        Task DeleteDetailtempAsync(int id);

        Task<Order> DeliveryOrder(Order model);

        Task DeleteOrder(Order model);

        Task<Order> GetOrderAsync(int id);
    }
}
