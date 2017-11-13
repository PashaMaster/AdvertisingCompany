using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingCompany.Models
{
    public class TypeAdvertising
    {
        public int TypeAdvertisingID { get; set; }
        public string NameTypeAdvertising { get; set; }
        public string DiscriptionTypeAdvertising { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
