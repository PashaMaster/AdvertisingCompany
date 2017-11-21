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
    public class OrdersController : Controller
    {
        private readonly OrderContext _context;

        public OrdersController(OrderContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;   // количество элементов на странице

            var source = _context.Orders.Include(o => o.Client).Include(o => o.ResponsibleOfficers).Include(o=> o.Location).ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Orders = items
            };
            return View(viewModel);
        }
        
        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.ResponsibleOfficers)
                .Include(o => o.Location)
                .SingleOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "NameClient");
            ViewData["ResponsibleOfficerID"] = new SelectList(_context.ResponsibleOfficers, "ResponsibleOfficerID", "NameResponsibleOfficer");
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "NameLocation");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,Date,DateOfBegin,DateOfEnd,ClientID,LocationID,Servise,Price,PaymentNote,ResponsibleOfficerID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "NameClient", order.ClientID);
            ViewData["ResponsibleOfficerID"] = new SelectList(_context.ResponsibleOfficers, "ResponsibleOfficerID", "NameResponsibleOfficer", order.ResponsibleOfficerID);
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "NameLocation",order.LocationID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.SingleOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "NameClient", order.ClientID);
            ViewData["ResponsibleOfficerID"] = new SelectList(_context.ResponsibleOfficers, "ResponsibleOfficerID", "NameResponsibleOfficer", order.ResponsibleOfficerID);
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "NameLocation", order.LocationID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,Date,DateOfBegin,DateOfEnd,ClientID,LocationID,Servise,Price,PaymentNote,ResponsibleOfficerID")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
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
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "NameClient", order.ClientID);
            ViewData["ResponsibleOfficerID"] = new SelectList(_context.ResponsibleOfficers, "ResponsibleOfficerID", "NameResponsibleOfficer", order.ResponsibleOfficerID);
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "NameLocation", order.LocationID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.ResponsibleOfficers)
                .Include(o => o.Location)
                .SingleOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(m => m.OrderID == id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
