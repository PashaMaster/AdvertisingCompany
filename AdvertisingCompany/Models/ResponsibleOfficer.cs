using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingCompany.Models
{
    public class ResponsibleOfficer
    {
        public int ResponsibleOfficerID { get; set; }
        public string NameResponsibleOfficer { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
