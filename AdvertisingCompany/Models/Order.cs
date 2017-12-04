using System;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingCompany.Models
{
    public class Order
    {
        [Key]
        [Display(Name = "Код заказа")]
        public int OrderID { get; set; }
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Display(Name = "Дата начала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBegin { get; set; }
        [Display(Name = "Дата окончания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfEnd { get; set; }
        public int ClientID { get; set; }
        public int LocationID { get; set; }
        [Display(Name = "Сервис")]
        public string Servise { get; set; }
        [Display(Name = "Цена")]
        public int Price { get; set; }
        [Display(Name = "Оценка об выполнении")]
        public int PaymentNote { get; set; }
        public int ResponsibleOfficerID { get; set; }
        public virtual Client Client { get; set; }
        public virtual ResponsibleOfficer ResponsibleOfficers { get; set; }
        public virtual Location Location { get; set; }
    }
}
