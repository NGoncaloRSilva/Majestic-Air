using Airline.Data.Entities;
using Airline.Helpers;
using Airline.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public OrderRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task<IQueryable<Order>> GetOrderAsync(string userName)
        {
            var user = await _userHelper.GetUserbyEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await _userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return _context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(p => p.Ticket)
                    .OrderByDescending(o => o.OrderDate);
            }

            return _context.Orders
                .Include(o => o.Items)
                .ThenInclude(p => p.Ticket)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.OrderDate);
        }

        public Task<IQueryable<Order>> GetOrderByUserNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IQueryable<OrderDetailTemp>> GetDetailsTempsAsync(string userName)
        {
            var user = await _userHelper.GetUserbyEmailAsync(userName);
            if (user == null)
            {
                return null;
            }


            return _context.OrderDetailsTemp
                .Include(p => p.Ticket)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.Ticket.Id);
        }

        public Task<IQueryable<OrderDetailTemp>> GetDetailsTempsByUserNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddItemToOrderAsync(TicketViewModel model, string userName)
        {
            var user = await _userHelper.GetUserbyEmailAsync(userName);

            if (user == null)
            { return; }

            var product = await _context.Tickets.FindAsync(model.Id);

            if (product == null)
            {
                return;
            }

            

            var orderDetailTemp = await _context.OrderDetailsTemp
                .Where(odt => odt.User == user && odt.Ticket == product)
                .FirstOrDefaultAsync();

            if (orderDetailTemp == null)
            {
                orderDetailTemp = new OrderDetailTemp
                {
                    Price = product.Price,
                    Ticket = product,
                    Quantity = model.Quantity,
                    User = user
                };

                _context.OrderDetailsTemp.Add(orderDetailTemp);
            }
            else
            {
                orderDetailTemp.Quantity += model.Quantity;
                _context.OrderDetailsTemp.Update(orderDetailTemp);
            }

            await _context.SaveChangesAsync();
        }
    }
}
