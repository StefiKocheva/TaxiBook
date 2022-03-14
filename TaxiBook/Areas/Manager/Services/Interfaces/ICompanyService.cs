namespace TaxiBook.Areas.Manager.Services.Interfaces
{
    using System.Collections.Generic;
    using ViewModels.Companies;

    public interface ICompanyService
    {
        IEnumerable<CompanyDetailsViewModel> Overview();

        IEnumerable<EmpployeeDetailsViewModel> EmployeesInCompany();
    }
}
