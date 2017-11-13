using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingCompany.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfBegin { get; set; }
        public DateTime DateOfEnd { get; set; }
        public int ClientID { get; set; }
        public int LocationID { get; set; }
        public string Servise { get; set; }
        public int Price { get; set; }
        public int PaymentNote { get; set; }
        public int ResponsibleOfficerID { get; set; }
        public virtual Client Client { get; set; }
        public virtual ResponsibleOfficer ResponsibleOfficers { get; set; }
    }
}
