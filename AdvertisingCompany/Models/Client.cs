using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingCompany.Models
{
    public class Client
    {
        [Key]
        [Display(Name = "Код клиента")]
        public int ClientID { get; set; }
        [Display(Name = "Имя клиента")]
        public string NameClient { get; set; }
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
        [Display(Name = "Номер телефона")]
        public int PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
