using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingCompany.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string NameLocation { get; set; }
        public string LocationT { get; set; }
        public int TypeAdvertisingID { get; set; }
        public int AdditionalServiseID { get; set; }
        public virtual AdditionalServise AdditionalServise { get; set; }
        public virtual TypeAdvertising TypeAdvertising { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
