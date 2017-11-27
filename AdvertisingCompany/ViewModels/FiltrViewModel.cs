using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using AdvertisingCompany.Models;

namespace AdvertisingCompany.ViewModels
{
    public class FiltrViewModel
    {
        public IEnumerable<Order> orders { get; set; }
        public SelectList Dates { get; set; }
        public string Name { get; set; }

        public FiltrViewModel(IEnumerable<Order> orders, SelectList Dates, string Name)
        {
            this.orders = orders;
            this.Dates = Dates;
            this.Name = Name;
        }
    }
}
