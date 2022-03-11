namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Companies;

    public class HomeController : Controller
    {
        private readonly ICompanyService companyService;

        public HomeController(ICompanyService companyService) 
            => this.companyService = companyService;
       
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var model = new CompanyListingViewModel();

            model.Companies = this.companyService.All();

            return this.View(model);
        }
    }
}
