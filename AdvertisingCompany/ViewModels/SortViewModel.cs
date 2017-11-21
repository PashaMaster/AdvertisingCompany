using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisingCompany.ViewModels;

namespace AdvertisingCompany.Models
{
    public class SortViewModel
    {
        public SortState NameClientSort { get; set; }
        public SortState PriceSort { get; set; }
        public SortState DateSort { get; set; }
        public SortState Current { get; set; }     
        public bool Up { get; set; }  

        public SortViewModel(SortState sortOrder)
        {

            NameClientSort = SortState.NameClientAsc;
            PriceSort = SortState.PriceAsc;
            DateSort = SortState.DateAsc;

            Up = true;

            if (sortOrder == SortState.PriceDesc || sortOrder == SortState.DateDesc
                || sortOrder == SortState.NameClientDesc)
            {
                Up = false;
            }

            switch (sortOrder)
            {
                case SortState.NameClientDesc:
                    Current = NameClientSort = SortState.NameClientAsc;
                    break;
                case SortState.PriceDesc:
                    Current = PriceSort = SortState.PriceAsc;
                    break;
                case SortState.PriceAsc:
                    Current = PriceSort = SortState.PriceDesc;
                    break;
                case SortState.DateDesc:
                    Current = DateSort = SortState.DateAsc;
                    break;
                case SortState.DateAsc:
                    Current = DateSort = SortState.DateDesc;
                    break;
                default:
                    Current = NameClientSort = SortState.NameClientDesc;
                    break;
            }
        }
    }
}
