using System.Collections.Generic;

namespace TaxiBook.Areas.Manager.ViewModels.Companies
{
    public class CompanyListingViewModel 
    {
        public IEnumerable<CompanyDetailsViewModel> Companies { get; set; } = new HashSet<CompanyDetailsViewModel>();

        public IEnumerable<EmpployeeDetailsViewModel> Employees { get; set; } = new HashSet<EmpployeeDetailsViewModel>();

    }
}
