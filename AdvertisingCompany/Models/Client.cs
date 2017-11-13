using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingCompany.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string NameClient { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
