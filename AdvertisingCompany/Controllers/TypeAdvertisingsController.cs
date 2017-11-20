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
    public class TypeAdvertisingsController : Controller
    {
        private readonly OrderContext _context;

        public TypeAdvertisingsController(OrderContext context)
        {
            _context = context;
        }

        // GET: TypeAdvertisings
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeAdvertisings.ToListAsync());
        }

        // GET: TypeAdvertisings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAdvertising = await _context.TypeAdvertisings
                .SingleOrDefaultAsync(m => m.TypeAdvertisingID == id);
            if (typeAdvertising == null)
            {
                return NotFound();
            }

            return View(typeAdvertising);
        }

        // GET: TypeAdvertisings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeAdvertisings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeAdvertisingID,NameTypeAdvertising,DiscriptionTypeAdvertising")] TypeAdvertising typeAdvertising)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeAdvertising);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeAdvertising);
        }

        // GET: TypeAdvertisings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAdvertising = await _context.TypeAdvertisings.SingleOrDefaultAsync(m => m.TypeAdvertisingID == id);
            if (typeAdvertising == null)
            {
                return NotFound();
            }
            return View(typeAdvertising);
        }

        // POST: TypeAdvertisings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeAdvertisingID,NameTypeAdvertising,DiscriptionTypeAdvertising")] TypeAdvertising typeAdvertising)
        {
            if (id != typeAdvertising.TypeAdvertisingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeAdvertising);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeAdvertisingExists(typeAdvertising.TypeAdvertisingID))
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
            return View(typeAdvertising);
        }

        // GET: TypeAdvertisings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAdvertising = await _context.TypeAdvertisings
                .SingleOrDefaultAsync(m => m.TypeAdvertisingID == id);
            if (typeAdvertising == null)
            {
                return NotFound();
            }

            return View(typeAdvertising);
        }

        // POST: TypeAdvertisings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeAdvertising = await _context.TypeAdvertisings.SingleOrDefaultAsync(m => m.TypeAdvertisingID == id);
            _context.TypeAdvertisings.Remove(typeAdvertising);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeAdvertisingExists(int id)
        {
            return _context.TypeAdvertisings.Any(e => e.TypeAdvertisingID == id);
        }
    }
}
