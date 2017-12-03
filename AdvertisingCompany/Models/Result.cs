using System;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingCompany.ViewModels
{
    public class Result
    {
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Locationc { get; set; }
        public string Place { get; set; }

        public Result(DateTime Date, string Locationc, string Place)
        {
            this.Date = Date;
            this.Locationc = Locationc;
            this.Place = Place;
        }
    }
}
