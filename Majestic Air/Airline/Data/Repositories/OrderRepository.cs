using Airline.Data.Entities;
using Airline.Helpers;
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
    }
}
