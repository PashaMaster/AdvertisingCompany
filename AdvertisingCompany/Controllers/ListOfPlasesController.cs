using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvertisingCompany.Models;
using AdvertisingCompany.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvertisingCompany.Controllers
{
    [Authorize]
    public class ListOfPlacesController : Controller
    {

        private readonly OrderContext _context;

        public ListOfPlacesController(OrderContext context)
        {
            _context = context;
        }
                
        public IActionResult DatePlaces(int page = 1)
        {
            IQueryable<Location> locations = _context.Locations.Include(p => p.AdditionalServise).Include(p => p.TypeAdvertising);
            int pageSize = 15;  var source = locations.ToList();
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

    public IActionResult DateNewspaper (int page = 1)
        {
            var date = DateTime.Now;
            IQueryable<Order> orders = _context.Orders
                .Where(p => p.DateOfBegin.Month >=date.Month && p.DateOfBegin.Month< date.Month+1);

            IQueryable<Location> locations = _context.Locations
                .Include(p => p.AdditionalServise)
                .Include(o => o.TypeAdvertising)
                .Where(p => p.TypeAdvertising.NameTypeAdvertising == "Реклама в прессе");

            var result = locations
                .Join(orders, 
                    p => p.LocationID, 
                    t => t.LocationID,
                    (p, t) => new
                    {
                        Date = t.DateOfBegin,
                        Locationc = p.LocationT,
                        Place = p.TypeAdvertising.NameTypeAdvertising
                    });
            List<Result> results = new List<Result>();
            foreach (var item in result)
            {
                results.Add(new Result(item.Date, item.Locationc, item.Place));
            }
            int pageSize = 15;   
            var source = results.ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Results = items                
            };
            return View(viewModel);
        }

    }
}