using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airline.Data;
using Airline.Data.Entities;
using Airline.Data.Repositories;
using Airline.Helpers;
using Airline.Models;
using Microsoft.AspNetCore.Authorization;

namespace Airline.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class TicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public TicketsController(ITicketRepository ticketRepository, IUserHelper userHelper, IConverterHelper converterHelper)
        {
            _ticketRepository = ticketRepository;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
        }

        // GET: Tickets
        [Authorize]
        public IActionResult Index()
        {
            return View(_ticketRepository.
                GetAll()
                .Include(p => p.FlightName)
                //.Include(p => p.Class)
                .OrderBy(p => p.Id));
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var model = await _ticketRepository.GetByIdAsyncwithFlight(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(model);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            var model = new TicketViewModel
            {
                Flights = _ticketRepository.GetComboFlight(),
                Classes = _ticketRepository.GetComboClass(0)
            };

            return View(model);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketViewModel ticket)
        {

            if (this.ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                ticket = await _ticketRepository.AddFlightAsync(ticket);

                var product = _converterHelper.toTicket(ticket, imageId, true);

                string inicial = product.Seat.Classe.Class.Substring(0, 1);


                List<Ticket> lista = (List<Ticket>)_ticketRepository.GetAll();
                Random _random = new Random();

                string number1 = (lista.Count + 1).ToString() + inicial;



                product.Code = number1;



                product.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);
                await _ticketRepository.CreateAsync(product);
                //No generic repository grava automaticamente
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var model = await _ticketRepository.GetByIdAsyncwithFlight(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }
            var viewmodel = _converterHelper.toTicketViewModel(model);

            viewmodel.Flights = _ticketRepository.GetComboFlight();
            viewmodel.Classes = _ticketRepository.GetComboClass(0);
            return View(viewmodel);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,TicketViewModel ticket)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Guid imageId = Guid.Empty;

                    ticket = await _ticketRepository.AddFlightAsync(ticket);

                    var product = _converterHelper.toTicket(ticket, imageId, false);


                    product.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);
                    await _ticketRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _ticketRepository.ExistAsync(ticket.Id))
                    {
                        return new NotFoundViewResult("ProductNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var model = await _ticketRepository.GetByIdAsync(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(model);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _ticketRepository.GetByIdAsync(id);
            await _ticketRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductNotFound()
        {
            return View();
        }
    }
}
