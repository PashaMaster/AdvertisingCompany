using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvertisingCompany.Models;

namespace AdvertisingCompany.Controllers
{
    public class ResponsibleOfficersController : Controller
    {
        private readonly OrderContext _context;

        public ResponsibleOfficersController(OrderContext context)
        {
            _context = context;
        }

        // GET: ResponsibleOfficers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResponsibleOfficers.ToListAsync());
        }

        // GET: ResponsibleOfficers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsibleOfficer = await _context.ResponsibleOfficers
                .SingleOrDefaultAsync(m => m.ResponsibleOfficerID == id);
            if (responsibleOfficer == null)
            {
                return NotFound();
            }

            return View(responsibleOfficer);
        }

        // GET: ResponsibleOfficers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResponsibleOfficers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponsibleOfficerID,NameResponsibleOfficer,Adress,PhoneNumber")] ResponsibleOfficer responsibleOfficer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsibleOfficer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsibleOfficer);
        }

        // GET: ResponsibleOfficers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsibleOfficer = await _context.ResponsibleOfficers.SingleOrDefaultAsync(m => m.ResponsibleOfficerID == id);
            if (responsibleOfficer == null)
            {
                return NotFound();
            }
            return View(responsibleOfficer);
        }

        // POST: ResponsibleOfficers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponsibleOfficerID,NameResponsibleOfficer,Adress,PhoneNumber")] ResponsibleOfficer responsibleOfficer)
        {
            if (id != responsibleOfficer.ResponsibleOfficerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsibleOfficer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsibleOfficerExists(responsibleOfficer.ResponsibleOfficerID))
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
            return View(responsibleOfficer);
        }

        // GET: ResponsibleOfficers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsibleOfficer = await _context.ResponsibleOfficers
                .SingleOrDefaultAsync(m => m.ResponsibleOfficerID == id);
            if (responsibleOfficer == null)
            {
                return NotFound();
            }

            return View(responsibleOfficer);
        }

        // POST: ResponsibleOfficers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsibleOfficer = await _context.ResponsibleOfficers.SingleOrDefaultAsync(m => m.ResponsibleOfficerID == id);
            _context.ResponsibleOfficers.Remove(responsibleOfficer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsibleOfficerExists(int id)
        {
            return _context.ResponsibleOfficers.Any(e => e.ResponsibleOfficerID == id);
        }
    }
}
