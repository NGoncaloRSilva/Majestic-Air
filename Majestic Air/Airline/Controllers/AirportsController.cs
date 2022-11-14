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
    [Authorize(Roles = "Admin")]
    public class AirportsController : Controller
    {
        private readonly IAirportsRepository _airportRepository;
        private readonly IUserHelper _userHelper;
        private readonly IBlobHelper _blobHelper;
        //private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public AirportsController(IAirportsRepository airportRepository, IUserHelper userHelper, IBlobHelper blobHelper, IConverterHelper converterHelper)
        {
            _airportRepository = airportRepository;
            _userHelper = userHelper;
            _blobHelper = blobHelper;
            //_imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }
        
        // GET: Airports
        public IActionResult Index()
        {
            return View(_airportRepository.GetAll().OrderBy(p => p.Name));
        }

        // GET: Airports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var model = await _airportRepository.GetByIdAsync(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(model);
        }

        // GET: Airports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AirportViewModel airports)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (airports.ImageFile != null && airports.ImageFile.Length > 0)
                {


                    imageId = await _blobHelper.UploadBlobAsync(airports.ImageFile, "countryflags");

                }


                var product = _converterHelper.toAirports(airports, imageId, true);




                product.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);
                await _airportRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Airports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var model = await _airportRepository.GetByIdAsync(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }
            var viewmodel = _converterHelper.toAirportViewModel(model);

            return View(viewmodel);
        }

        // POST: Airports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,AirportViewModel airports)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Guid imageId = Guid.Empty;

                    if (airports.ImageFile != null && airports.ImageFile.Length > 0)
                    {


                        imageId = await _blobHelper.UploadBlobAsync(airports.ImageFile, "countryflags");

                    }


                    var product = _converterHelper.toAirports(airports, imageId, false);


                    product.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);
                    await _airportRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _airportRepository.ExistAsync(airports.Id))
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
            return View(airports);
        }

        // GET: Airports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var model = await _airportRepository.GetByIdAsync(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(model);
        }

        // POST: Airports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _airportRepository.GetByIdAsync(id);
            await _airportRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult ProductNotFound()
        {
            return View();
        }
    }
}
