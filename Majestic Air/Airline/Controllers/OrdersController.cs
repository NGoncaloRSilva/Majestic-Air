using Airline.Data.Repositories;
using Airline.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Airline.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketRepository _ticketRepository;

        public OrdersController(IOrderRepository orderRepository, ITicketRepository ticketRepository)
        {
            _orderRepository = orderRepository;
            _ticketRepository = ticketRepository;
        }


        public async Task<IActionResult> Index()
        {
            var model = await _orderRepository.GetOrderAsync(this.User.Identity.Name);

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = await _orderRepository.GetDetailsTempsAsync(this.User.Identity.Name);

            return View(model);
        }

        public IActionResult AddTicket()
        {
            var model = new AddTicketsViewModel
            {
                Quantity = 1,
                Tickets = _ticketRepository.GetComboTickets()
            };

            return View(model);
        }
    }
}
