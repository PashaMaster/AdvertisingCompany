using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingCompany.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<AdditionalServise> AdditionalServises { get; set; }
        public IEnumerable<TypeAdvertising> TypeAdvertisings { get; set; }
        public IEnumerable<ResponsibleOfficer> ResponsibleOfficers { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
