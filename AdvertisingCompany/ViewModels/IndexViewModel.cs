using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using AdvertisingCompany.ViewModels;

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
        public SortViewModel SortViewModel { get; set; }
        public FiltrViewModel FiltrViewModel { get; set; }
    }
}
