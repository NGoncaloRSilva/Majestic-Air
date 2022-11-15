using Airline.Data.Entities;
using Airline.Data.Repositories;
using Airline.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Airline.Helpers;
using System.Linq;

namespace Airline.Controllers
{
    
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

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var model = await _orderRepository.GetOrderAsync(this.User.Identity.Name);

            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var model = await _orderRepository.GetDetailsTempsAsync(this.User.Identity.Name);

            return View(model);
        }

        public async Task<IActionResult> AddTicket()
        {
            var model = new TicketViewModel
            {
                
                Flights = _ticketRepository.GetComboFlight(),
                Classes = _ticketRepository.GetComboClass(0)
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







                    var lista = _ticketRepository.GetcomboTicket();
                    Random _random = new Random();

                    string number1 = (lista.Count() + 1).ToString() + inicial;

                    


                    product.Code = number1;



                    product.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);
                    await _ticketRepository.CreateAsync(product);

                ticket.Id = lista.Count() + 1;



                await _orderRepository.AddItemToOrderAsync(ticket, this.User.Identity.Name);
                return RedirectToAction("Create");
            }

            return View(ticket);
        }

        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _orderRepository.DeleteDetailtempAsync(id.Value);
            return RedirectToAction("Create");
        }

        //public async Task<IActionResult> Increase(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    await _orderRepository.ModifyOrderDetailTempQuantity(id.Value, 1);
        //    return RedirectToAction("Create");
        //}

        //public async Task<IActionResult> Decrease(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    await _orderRepository.ModifyOrderDetailTempQuantity(id.Value, -1);
        //    return RedirectToAction("Create");
        //}

        [Authorize]
        public async Task<IActionResult> ConfirmOrder()
        {
            var response = await _orderRepository.ConfirmOrderAsync(this.User.Identity.Name);
            if (response)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");

        }

       

        [HttpPost]
        [Route("Orders/GetClassesAsync")]
        public async Task<JsonResult> GetClassesAsync(int flightId)
        {
            var classes = await _ticketRepository.VerifyStock(flightId);


            return Json(classes.OrderBy(c => c.Value));
        }
    }
}
