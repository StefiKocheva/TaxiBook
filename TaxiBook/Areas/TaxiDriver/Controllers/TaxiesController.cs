namespace TaxiBook.Areas.TaxiDriver.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using ViewModels.Taxies;

    [Authorize(Roles = "TaxiDriver")]
    [Area("TaxiDriver")]
    public class TaxiesController : Controller
    {
        private readonly ITaxiService taxiService;

        public TaxiesController(ITaxiService taxiService) 
            => this.taxiService = taxiService;

        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            var viewModel = await this.taxiService.OverviewAsync();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaxiInformationViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Overview", viewModel);
            }

            await this.taxiService.EditAsync(
                viewModel.UpdateTaxiViewModel.Brand,
                viewModel.UpdateTaxiViewModel.Model,
                viewModel.UpdateTaxiViewModel.NumberPlate);

            return this.RedirectToAction("Overview");
        }
    }
}
