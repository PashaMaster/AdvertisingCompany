using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvertisingCompany.Models;
using Microsoft.AspNetCore.Authorization;

namespace AdvertisingCompany.Controllers
{
    [Authorize]
    public class LocationsController : Controller
    {
        private readonly OrderContext _context;

        public LocationsController(OrderContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;   // количество элементов на странице

            var source = _context.Locations
                .Include(l => l.AdditionalServise)
                .Include(l => l.TypeAdvertising)
                .ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Locations = items
            };
            return View(viewModel);
        }
        
        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .Include(l => l.AdditionalServise)
                .Include(l => l.TypeAdvertising)
                .SingleOrDefaultAsync(m => m.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            ViewData["AdditionalServiseID"] = new SelectList(_context.AdditionalServises, "AdditionalServiseID", "NameAdditionalServise");
            ViewData["TypeAdvertisingID"] = new SelectList(_context.TypeAdvertisings, "TypeAdvertisingID", "NameTypeAdvertising");
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationID,NameLocation,LocationT,TypeAdvertisingID,AdditionalServiseID")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdditionalServiseID"] = new SelectList(_context.AdditionalServises, "AdditionalServiseID", "NameAdditionalServise", location.AdditionalServiseID);
            ViewData["TypeAdvertisingID"] = new SelectList(_context.TypeAdvertisings, "TypeAdvertisingID", "NameTypeAdvertising", location.TypeAdvertisingID);
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations.SingleOrDefaultAsync(m => m.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }
            ViewData["AdditionalServiseID"] = new SelectList(_context.AdditionalServises, "AdditionalServiseID", "NameAdditionalServise", location.AdditionalServiseID);
            ViewData["TypeAdvertisingID"] = new SelectList(_context.TypeAdvertisings, "TypeAdvertisingID", "NameTypeAdvertising", location.TypeAdvertisingID);
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationID,NameLocation,LocationT,TypeAdvertisingID,AdditionalServiseID")] Location location)
        {
            if (id != location.LocationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationID))
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
            ViewData["AdditionalServiseID"] = new SelectList(_context.AdditionalServises, "AdditionalServiseID", "NameAdditionalServise", location.AdditionalServiseID);
            ViewData["TypeAdvertisingID"] = new SelectList(_context.TypeAdvertisings, "TypeAdvertisingID", "NameTypeAdvertising", location.TypeAdvertisingID);
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .Include(l => l.AdditionalServise)
                .Include(l => l.TypeAdvertising)
                .SingleOrDefaultAsync(m => m.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations.SingleOrDefaultAsync(m => m.LocationID == id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationID == id);
        }
    }
}
