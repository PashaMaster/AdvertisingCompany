using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingCompany.Models
{
    public class AdditionalServise
    {
        public int AdditionalServiseID { get; set; }
        public string NameAdditionalServise { get; set; }
        public string DiscriptionAdditionalServise { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
