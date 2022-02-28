using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiBook.Services.ViewModels.Companies
{
    public class CompanyListingViewModel
    {
        public IEnumerable<CompanyDetailsViewModel> Companies { get; set; } = new HashSet<CompanyDetailsViewModel>();
    }
}
