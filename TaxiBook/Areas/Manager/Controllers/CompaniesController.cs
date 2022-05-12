namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using ViewModels.Companies;

    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService companyService;

        public CompaniesController(ICompanyService companyService)
            => this.companyService = companyService;

        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            var viewModel = await this.companyService.OverviewAsync();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(
            string id, 
            CompanyInformationViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Overview", viewModel);
            }

            await this.companyService.EditAsync(
                id,
                viewModel.UpdateCompanyViewModel.Name,
                viewModel.UpdateCompanyViewModel.Description,
                viewModel.UpdateCompanyViewModel.PhoneNumber,
                viewModel.UpdateCompanyViewModel.Province,
                viewModel.UpdateCompanyViewModel.OneКilometerМileageDailyPrice,
                viewModel.UpdateCompanyViewModel.DailyPricePerCall,
                viewModel.UpdateCompanyViewModel.InitialDailyFee,
                viewModel.UpdateCompanyViewModel.DailyPricePerMinuteStay,
                viewModel.UpdateCompanyViewModel.OneКilometerМileageNightPrice,
                viewModel.UpdateCompanyViewModel.NightPricePerCall,
                viewModel.UpdateCompanyViewModel.InitialNightFee,
                viewModel.UpdateCompanyViewModel.NightPricePerMinuteStay);

            return this.RedirectToAction("Overview");
        }
    }
}
