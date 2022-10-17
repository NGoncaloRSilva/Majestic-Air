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
    public class AirshipsController : Controller
    {
        private readonly IAirshipRepository _airshipRepository;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public AirshipsController(IAirshipRepository airshipRepository,  IUserHelper userHelper, IBlobHelper blobHelper, IConverterHelper converterHelper)
        {
            _airshipRepository = airshipRepository;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
        }
        [Authorize(Roles = "Admin")]
        // GET: Airships
        public IActionResult Index()
        {
           

            return View(_airshipRepository
                .GetAll()
                .Include(p => p.model)
                .OrderBy(p => p.AirshipName));
        }

        // GET: Airships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var model = await _airshipRepository.GetByIdAsyncwithModel(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(model);
        }

        // GET: Airships/Create
        public IActionResult Create()
        {
            var model = new AirshipViewModel
            {
                ListModel = _airshipRepository.GetComboModels()
            };

            //model.model = new Model();

            return View(model);
        }

        // POST: Airships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AirshipViewModel airship)
        {
            
            if (this.ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                airship = await _airshipRepository.AddModelAsync(airship);

                airship.model.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);


                var product = _converterHelper.toAirship(airship, imageId, true);

                //TODO: Modificar para o que tiver logado
                product.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);
                await _airshipRepository.CreateAsync(product);
                //No generic repository grava automaticamente
                return RedirectToAction(nameof(Index));
            }
            return View(airship);
        }

        // GET: Airships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            //usar o :include
            
            var model = await _airshipRepository.GetByIdAsyncwithModel(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }
            var viewmodel = _converterHelper.toAirshipViewModel(model);
            viewmodel.ListModel = _airshipRepository.GetComboModels();

            return View(viewmodel);
        }

        // POST: Airships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AirshipViewModel airship)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Guid imageId = Guid.Empty;

                    airship = await _airshipRepository.AddModelAsync(airship);

                    airship.model.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);

                    var product = _converterHelper.toAirship(airship, imageId, false);


                    product.User = await _userHelper.GetUserbyEmailAsync(this.User.Identity.Name);
                    await _airshipRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _airshipRepository.ExistAsync(airship.Id))
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
            return View(airship);
        }

        // GET: Airships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var model = await _airshipRepository.GetByIdAsyncwithModel(id.Value);
            if (model == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            

            return View(model);
        }

        // POST: Airships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _airshipRepository.GetByIdAsync(id);
            await _airshipRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductNotFound()
        {
            return View();
        }

        
    }
}
