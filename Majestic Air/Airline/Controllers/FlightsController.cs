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
using System.Data;

namespace Airline.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public FlightsController(IFlightRepository flightRepository, IUserHelper userHelper, IBlobHelper blobHelper, IConverterHelper converterHelper)
        {
            _flightRepository = flightRepository;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
        }

        // GET: Flights
        [Authorize]
        public IActionResult Index()
        {
            return View(_flightRepository.
                GetAll()
                .Include(p => p.AirshipName)
                .ThenInclude(p => p.model)
                .Include(p => p.Destination)
                .Include(p => p.Origin)
                .Include(p => p.FlightNumber)
                .OrderBy(p => p.Day));

            
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var model = await _flightRepository.GetByIdAsyncwithAirshipAirport(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(model);
        }

        // GET: Flights/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = new FlightViewModel
            {
                ListAirports = _flightRepository.GetComboAirport(),
                ListAirships = _flightRepository.GetComboAirship()
            };

            return View(model);
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightViewModel flight)
        {
            if (this.ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                flight = await _flightRepository.AddAirportAirshipAsync(flight);

                var product = _converterHelper.toFlight(flight, imageId, true);

                string inicial = product.AirshipName.AirshipName.Substring(0, 1);

               
                List<Flight> lista = (List < Flight >)_flightRepository.GetAll();
                Random _random = new Random();

                string number1 = (lista.Count + 1).ToString() + inicial;



                product.FlightNumber = number1;

                

                product.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);
                await _flightRepository.CreateAsync(product);
                //No generic repository grava automaticamente
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var model = await _flightRepository.GetByIdAsyncwithAirshipAirport(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }
            var viewmodel = _converterHelper.toFlightViewModel(model);

            viewmodel.ListAirports = _flightRepository.GetComboAirport();
            viewmodel.ListAirships = _flightRepository.GetComboAirship();

            return View(viewmodel);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,FlightViewModel flight)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    Guid imageId = Guid.Empty;

                    flight = await _flightRepository.AddAirportAirshipAsync(flight);

                    flight = await _flightRepository.AddNumberAsync(flight);

                    var product = _converterHelper.toFlight(flight, imageId, false);


                    product.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);
                    await _flightRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _flightRepository.ExistAsync(flight.Id))
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
            return View(flight);
        }

        // GET: Flights/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var model = await _flightRepository.GetByIdAsync(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(model);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _flightRepository.GetByIdAsync(id);
            await _flightRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductNotFound()
        {
            return View();
        }

        
    }
}
