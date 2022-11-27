using Airline.Data.Entities;
using Airline.Helpers;
using Airline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                    .Include(u => u.User)
                    .Include(o => o.Items)
                    .ThenInclude(p => p.Ticket)
                    .ThenInclude(p => p.Seat)  
                    .OrderByDescending(o => o.OrderDate);
            }

            return _context.Orders
                .Include(o => o.Items)
                .ThenInclude(p => p.Ticket)
                .ThenInclude(p => p.Seat)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.OrderDate);
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
                .ThenInclude(p => p.FlightName)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.Ticket.Id);
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
                .Include(p => p.Ticket)
                .ThenInclude(p => p.FlightName)
                //.Include(p=> p.Ticket.Class)
                .Where(odt => odt.User == user && odt.Ticket.FlightName == product.FlightName && odt.Ticket.Id == product.Id)
                .FirstOrDefaultAsync();

            if (orderDetailTemp == null)
            {
                orderDetailTemp = new OrderDetailTemp
                {
                    Price = product.Price,
                    Ticket = product,
                    User = user
                };

                _context.OrderDetailsTemp.Add(orderDetailTemp);
            }
            else
            {
                
                _context.OrderDetailsTemp.Update(orderDetailTemp);
            }

            await _context.SaveChangesAsync();
        }

        //public async Task ModifyOrderDetailTempQuantity(int id, double quantity)
        //{
        //    var orderDetailTemp = await _context.OrderDetailsTemp.FindAsync(id);
        //    if (orderDetailTemp == null)
        //    {
        //        return;
        //    }

        //    orderDetailTemp.Quantity += quantity;
        //    if (orderDetailTemp.Quantity > 0)
        //    {
        //        _context.OrderDetailsTemp.Update(orderDetailTemp);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        public async Task DeleteDetailtempAsync(int id)
        {
            var orderDetailTemp = await _context.OrderDetailsTemp.FindAsync(id);

            if (orderDetailTemp == null)
            {
                return;
            }

            var model = await _context.Set<OrderDetailTemp>()
                .Include(p => p.Ticket)
                .ThenInclude(p=> p.Seat)
                .OrderBy(a => a.Id).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            var seat = await _context.Seats.FindAsync(model.Ticket.Seat.Id);

            seat.Available = true;

            _context.Set<Seats>().Update(seat);

            await _context.SaveChangesAsync();

            _context.OrderDetailsTemp.Remove(orderDetailTemp);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ConfirmOrderAsync(string username)
        {
            var user = await _userHelper.GetUserbyEmailAsync(username);
            if (user == null)
            {
                return false;
            }

            var orderTmps = await _context.OrderDetailsTemp
                .Include(o => o.Ticket)
                .Where(o => o.User == user)
                .ToListAsync();

            if (orderTmps == null || orderTmps.Count == 0)
            {
                return false;
            }

            var details = orderTmps.Select(o => new OrderDetail
            {
                Price = o.Price,
                Ticket = o.Ticket,
                //Quantity = o.Quantity,
            }).ToList();



            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                User = user,
                Items = details,
                Status = "Awaiting Payment"
                
            };

            await CreateAsync(order);

            _context.OrderDetailsTemp.RemoveRange(orderTmps);
            await _context.SaveChangesAsync();

            return true;


        }

        public async Task<Order> DeliveryOrder(Order model)
        {
            var order = await _context.Orders.FindAsync(model.Id);

            var order2 = await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(o => o.Ticket)
                .ThenInclude(o => o.Seat)
                .Include(o=> o.User)
                .Where(o => o.Id == model.Id).FirstOrDefaultAsync();

            if (order == null)
            {
                return (model);
            }

            order.Status = "Payment Concluded";
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            model.Items = order2.Items;
            model.User = order2.User;
            model.Status = order.Status;

            return (model);
        }

        public async Task DeleteOrder(Order model)
        {
            var order = await _context.Orders.FindAsync(model.Id);

            if (order == null)
            {
                return;
            }

            order.Status = "Canceled";
            _context.Orders.Update(order);

            var order2 = await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(o => o.Ticket)
                .ThenInclude(o => o.Seat)
                .Where(o => o.Id == model.Id).FirstOrDefaultAsync();

            var list2 = new List<Seats>();

            foreach (var item in order2.Items)
            {
                list2.Add(item.Ticket.Seat);
            }

            foreach (var item in list2)
            {
                item.Available = true;
                _context.Set<Seats>().Update(item);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            var order2 = await _context.Set<Order>()
                .Include(o => o.Items)
                .ThenInclude(p => p.Ticket)
                .ThenInclude(p => p.Seat)
                .Where(o => o.Id == id)
                .OrderByDescending(o => o.OrderDate)
                .AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            

            var order = await _context.Orders.FindAsync(id);

            order.Items = order2.Items;

            return order;
        }

        
    }
}
