
namespace AdvertisingCompany.Models
{
    public enum SortState
    {
        NameClientAsc,
        NameClientDesc,
        PriceAsc,
        PriceDesc,
        DateAsc,
        DateDesc
    }

    public class SortViewModel
    {
        public SortState NameClientSort { get; set; }
        public SortState PriceSort { get; set; }
        public SortState DateSort { get; set; }
        public SortState Current { get; set; }     
        public bool Up { get; set; }  

        public SortViewModel(SortState sortOrder)
        {

            NameClientSort = sortOrder == SortState.NameClientAsc ? SortState.NameClientDesc : SortState.NameClientAsc;
            DateSort = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            Current = sortOrder;
        }
    }
}
