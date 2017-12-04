using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingCompany.Models
{
    public class Location
    {
        [Key]
        [Display(Name = "Код локации")]
        public int LocationID { get; set; }
        [Display(Name = "Название локации")]
        public string NameLocation { get; set; }
        [Display(Name = "Локация")]
        public string LocationT { get; set; }
        public int TypeAdvertisingID { get; set; }
        public int AdditionalServiseID { get; set; }
        public virtual AdditionalServise AdditionalServise { get; set; }
        public virtual TypeAdvertising TypeAdvertising { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
