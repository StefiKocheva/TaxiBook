namespace TaxiBook.Areas.TaxiDriver.ViewModels.Taxies
{
    using System.Collections.Generic;

    public class TaxiListingViewModel
    {
        public IEnumerable<TaxiDetailsViewModel> Taxies { get; set; }
    }
}
