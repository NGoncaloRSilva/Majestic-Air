using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airline.Data;
using Airline.Data.Entities;

namespace Airline.Controllers
{
    public class AirshipsController : Controller
    {
        private readonly DataContext _context;

        public AirshipsController(DataContext context)
        {
            _context = context;
        }

        // GET: Airships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Airships.ToListAsync());
        }

        // GET: Airships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airship = await _context.Airships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airship == null)
            {
                return NotFound();
            }

            return View(airship);
        }

        // GET: Airships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AirshipName,CreationDate")] Airship airship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airship);
        }

        // GET: Airships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airship = await _context.Airships.FindAsync(id);
            if (airship == null)
            {
                return NotFound();
            }
            return View(airship);
        }

        // POST: Airships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AirshipName,CreationDate")] Airship airship)
        {
            if (id != airship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirshipExists(airship.Id))
                    {
                        return NotFound();
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
                return NotFound();
            }

            var airship = await _context.Airships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airship == null)
            {
                return NotFound();
            }

            return View(airship);
        }

        // POST: Airships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airship = await _context.Airships.FindAsync(id);
            _context.Airships.Remove(airship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirshipExists(int id)
        {
            return _context.Airships.Any(e => e.Id == id);
        }
    }
}
