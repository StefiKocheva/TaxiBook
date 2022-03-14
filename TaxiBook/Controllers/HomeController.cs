namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Companies;

    [Authorize(Roles = "Client,TaxiDriver,Dispatcher,Manager")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ICompanyService companyService;

        public HomeController(ICompanyService companyService) 
            => this.companyService = companyService;

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new CompanyListingViewModel
            {
                Companies = this.companyService.TopFive()
            };

            return this.View(viewModel);
        }
        
        [HttpGet]
        public IActionResult Dashboard()
        {
            var viewModel = new CompanyListingViewModel
            {
                Companies = this.companyService.All()
            };

            return this.View(viewModel);
        }
    }
}
