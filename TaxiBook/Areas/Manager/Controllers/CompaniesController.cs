namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using ViewModels.Companies;

    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService companyService;

        public CompaniesController(ICompanyService companyService)
            => this.companyService = companyService;

        [HttpGet]
        public IActionResult Overview()
        {
            var viewModel = new CompanyListingViewModel
            {
                Companies = this.companyService.Overview(),
                Employees = this.companyService.EmployeesInCompany(),
            };

            return this.View(viewModel);
        }
    }
}
