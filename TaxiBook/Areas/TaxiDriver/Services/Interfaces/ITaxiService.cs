namespace TaxiBook.Areas.TaxiDriver.Services.Interfaces
{
    using System.Collections.Generic;
    using ViewModels.Taxies;

    public interface ITaxiService
    {
        IEnumerable<TaxiDetailsViewModel> Overview();
    }
}
