using Airline.Data.Entities;
using Airline.Data.Repositories;
using Airline.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Airline.Helpers;

namespace Airline.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public OrdersController(IOrderRepository orderRepository, ITicketRepository ticketRepository, IUserHelper userHelper, IConverterHelper converterHelper)
        {
            _orderRepository = orderRepository;
            _ticketRepository = ticketRepository;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
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
            var model = new TicketViewModel
            {
                Quantity = 1,
                Flights = _ticketRepository.GetComboFlight(),
                Classes = _ticketRepository.GetComboClass()
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(TicketViewModel ticket)
        {
            if (ModelState.IsValid)
            {
                    Guid imageId = Guid.Empty;
                    ticket = await _ticketRepository.AddFlightAsync(ticket);

                    var product = _converterHelper.toTicket(ticket, imageId, true);

                    string inicial = product.Class.Class.Substring(0, 1);


                    List<Ticket> lista = (List<Ticket>)_ticketRepository.GetAll();
                    Random _random = new Random();

                    string number1 = (lista.Count + 1).ToString() + inicial;

                    


                    product.Code = number1;



                    product.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);
                    await _ticketRepository.CreateAsync(product);
                

                await _orderRepository.AddItemToOrderAsync(ticket, this.User.Identity.Name);
                return RedirectToAction("Create");
            }

            return View(ticket);
        }
    }
}
