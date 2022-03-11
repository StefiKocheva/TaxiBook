namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Services.Interfaces;
    using Services.ViewModels.Companies;
    using Microsoft.AspNetCore.Mvc;

    public class CompaniesController : Controller
    {
        private readonly ICompanyService companyService;

        public CompaniesController(ICompanyService companyService)
            => this.companyService = companyService;

        [HttpGet]
        public IActionResult All()
        {
            var model = new CompanyListingViewModel();

            model.Companies = this.companyService.All();

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.companyService.CreateAsync(
                viewModel.Name,
                viewModel.PhoneNumber,
                viewModel.Description,
                //model.License,
                viewModel.Province,
                viewModel.OneКilometerМileageDailyPrice,
                viewModel.OneКilometerМileageNightPrice,
                viewModel.DailyPricePerCall,
                viewModel.NightPricePerCall,
                viewModel.InitialDailyFee,
                viewModel.InitialNightFee,
                viewModel.DailyPricePerMinuteStay,
                viewModel.NightPricePerMinuteStay);

            return this.RedirectToAction("All");
        }
    }
}
