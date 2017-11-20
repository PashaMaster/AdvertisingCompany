using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvertisingCompany.Models;
using Microsoft.AspNetCore.Authorization;

namespace AdvertisingCompany.Controllers
{
    [Authorize]
    public class AdditionalServisesController : Controller
    {
        private readonly OrderContext _context;

        public AdditionalServisesController(OrderContext context)
        {
            _context = context;
        }

        // GET: AdditionalServises
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdditionalServises.ToListAsync());
        }

        // GET: AdditionalServises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var additionalServise = await _context.AdditionalServises
                .SingleOrDefaultAsync(m => m.AdditionalServiseID == id);
            if (additionalServise == null)
            {
                return NotFound();
            }

            return View(additionalServise);
        }

        // GET: AdditionalServises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdditionalServises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdditionalServiseID,NameAdditionalServise,DiscriptionAdditionalServise")] AdditionalServise additionalServise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(additionalServise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(additionalServise);
        }

        // GET: AdditionalServises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var additionalServise = await _context.AdditionalServises.SingleOrDefaultAsync(m => m.AdditionalServiseID == id);
            if (additionalServise == null)
            {
                return NotFound();
            }
            return View(additionalServise);
        }

        // POST: AdditionalServises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdditionalServiseID,NameAdditionalServise,DiscriptionAdditionalServise")] AdditionalServise additionalServise)
        {
            if (id != additionalServise.AdditionalServiseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(additionalServise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdditionalServiseExists(additionalServise.AdditionalServiseID))
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
            return View(additionalServise);
        }

        // GET: AdditionalServises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var additionalServise = await _context.AdditionalServises
                .SingleOrDefaultAsync(m => m.AdditionalServiseID == id);
            if (additionalServise == null)
            {
                return NotFound();
            }

            return View(additionalServise);
        }

        // POST: AdditionalServises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var additionalServise = await _context.AdditionalServises.SingleOrDefaultAsync(m => m.AdditionalServiseID == id);
            _context.AdditionalServises.Remove(additionalServise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdditionalServiseExists(int id)
        {
            return _context.AdditionalServises.Any(e => e.AdditionalServiseID == id);
        }
    }
}
