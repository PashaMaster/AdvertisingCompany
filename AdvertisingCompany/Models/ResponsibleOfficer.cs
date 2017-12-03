using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingCompany.Models
{
    public class ResponsibleOfficer
    {
        [Key]
        [Display(Name = "Код сотрудника")]
        public int ResponsibleOfficerID { get; set; }
        [Display(Name = "Имя сотрудника")]
        public string NameResponsibleOfficer { get; set; }
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
        [Display(Name = "Номер телефона")]
        public int PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
