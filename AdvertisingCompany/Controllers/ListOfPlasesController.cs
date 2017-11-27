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
    public class ListOfPlasesController : Controller
    {

        private readonly OrderContext _context;

        public ListOfPlasesController(OrderContext context)
        {
            _context = context;
        }

        public IActionResult DateNewspaper(DateTime? date, string name, int page = 1)
        {
            IQueryable<Order> orders = _context.Orders.Include(p => p.Client).Include(p => p.ResponsibleOfficers);
            if (date != null)
            {
                orders = orders.Where(p => p.DateOfBegin == date);
            }
            if (!String.IsNullOrEmpty(name))
            {
                orders = orders.Where(p => p.Client.NameClient.Contains(name));
            }

            List<DateTime> dates = _context.Orders.Select(x => x.DateOfBegin).ToList();
            
            int pageSize = 15;   // количество элементов на странице

            var source = orders.ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            FiltrViewModel filtrViewModel = new FiltrViewModel(items, new SelectList(dates), name);

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                FiltrViewModel = filtrViewModel,
                Orders = items                
            };

            return View(viewModel);
        }



    }
}