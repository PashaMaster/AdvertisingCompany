using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using AdvertisingCompany.Models;

namespace AdvertisingCompany.ViewModels
{
    public class FiltrViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public int PaymentNote { get; set; }
        public string NameClient { get; set; }
        public string NameLocation { get; set; }
        public string NameService { get; set; }

        public FiltrViewModel(IEnumerable<Order> Orders, int PaymentNote, string NameClient, string NameLocation, string Service)
        {
            this.Orders = Orders;
            this.PaymentNote = PaymentNote;
            this.NameClient = NameClient;
            this.NameLocation = NameLocation;
            this.NameService = NameService;
        }
    }
}
