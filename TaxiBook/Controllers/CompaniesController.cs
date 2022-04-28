namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Services.Interfaces;
    using Services.ViewModels.Companies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService companyService;
        
        public CompaniesController(ICompanyService companyService)
            => this.companyService = companyService;

        [AllowAnonymous]
        [HttpGet]
        public IActionResult All()
        {
            var viewModel = new CompanyListingViewModel
            {
                Companies = this.companyService.All()
            };

            return this.View(viewModel);
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var model = await this.companyService.DetailsAsync(id);

            return this.View(model);
        }
    }
}
