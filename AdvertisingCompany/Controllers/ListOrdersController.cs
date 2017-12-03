using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvertisingCompany.Models;
using Microsoft.AspNetCore.Authorization;
using AdvertisingCompany.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvertisingCompany.Controllers
{
    [Authorize]
    public class ListOrdersController : Controller
    {
        private readonly OrderContext _context;

        public ListOrdersController(OrderContext context)
        {
            _context = context;
        }

        public IActionResult AllOrders(int paymentNote, string nameClient, string nameLocation, string service, int page = 1)
        {
            IQueryable<Order> orders = _context.Orders.Include(o => o.Client).Include(o => o.ResponsibleOfficers).Include(o => o.Location);
           
            if (paymentNote != 0)
            {
                orders = orders.Where(p => p.PaymentNote == paymentNote);
            }

            if (!String.IsNullOrEmpty(nameClient))
            {
                orders = orders.Where(p => p.Client.NameClient.Contains(nameClient));
            }

            if (!String.IsNullOrEmpty(nameLocation))
            {
                orders = orders.Where(p => p.Location.NameLocation.Contains(nameLocation));
            }

            if (!String.IsNullOrEmpty(service))
            {
                orders = orders.Where(p => p.Servise.Contains(service));
            }

            FiltrViewModel filtrViewModel = new FiltrViewModel(orders, paymentNote, nameClient, nameLocation, service);

            int pageSize = 15; 
            var source = orders.ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            
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