using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingCompany.Models
{
    public class TypeAdvertising
    { 
        [Key]
        [Display(Name = "Код типа рекламы")]
        public int TypeAdvertisingID { get; set; }
        [Display(Name = "Имя типа рекламы")]
        public string NameTypeAdvertising { get; set; }
        [Display(Name = "Описание типа рекламы")]
        public string DiscriptionTypeAdvertising { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
