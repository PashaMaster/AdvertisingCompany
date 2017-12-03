using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingCompany.Models
{
    public class AdditionalServise
    {
        [Key]
        [Display(Name = "Код дополнительного сервиса")]
        public int AdditionalServiseID { get; set; }
        [Display(Name = "Название")]
        public string NameAdditionalServise { get; set; }
        [Display(Name = "Описание")]
        public string DiscriptionAdditionalServise { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
