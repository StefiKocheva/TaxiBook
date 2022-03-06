namespace TaxiBook.Areas.Manager.ViewModels.Employees
{
    using System.Collections.Generic;

    public class EmployeeListingViewModel
    {
        public IEnumerable<EmployeeDetailsViewModel> Employees { get; set; } = new HashSet<EmployeeDetailsViewModel>();
    }
}
