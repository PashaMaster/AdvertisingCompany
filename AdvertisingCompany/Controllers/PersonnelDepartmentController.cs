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
    public class PersonnelDepartmentController : Controller
    {
           
        private readonly OrderContext _context;

        public PersonnelDepartmentController(OrderContext context)
        {
            _context = context;
        }

        // GET:
        public async Task<IActionResult> DataClient(int page = 1)
        {
            int pageSize = 10;   // количество элементов на странице

            var source = _context.Clients.ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Clients = items
            };

            return View(viewModel);
        }

        // GET:
        public async Task<IActionResult> DataClientPaymentNote(int page = 1)
        {
            int pageSize = 10;   // количество элементов на странице

            var source = _context.Orders
                .Include(x=>x.Client)
                .Include(x=>x.ResponsibleOfficers)
                .Where(x=>x.PaymentNote==1)
                .ToList();
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


    }
}