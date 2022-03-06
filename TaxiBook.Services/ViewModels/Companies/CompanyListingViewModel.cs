namespace TaxiBook.Services.ViewModels.Companies
{
    using System.Collections.Generic;

    public class CompanyListingViewModel
    {
        public IEnumerable<CompanyDetailsViewModel> Companies { get; set; } = new HashSet<CompanyDetailsViewModel>();
    }
}
