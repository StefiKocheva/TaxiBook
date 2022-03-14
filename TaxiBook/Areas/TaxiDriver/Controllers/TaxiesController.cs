namespace TaxiBook.Areas.TaxiDriver.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using ViewModels.Taxies;

    [Authorize(Roles = "TaxiDriver")]
    [Area("TaxiDriver")]
    public class TaxiesController : Controller
    {
        private readonly ITaxiService taxiService;

        public TaxiesController(ITaxiService taxiService) 
            => this.taxiService = taxiService;

        [HttpGet]
        public IActionResult Overview()
        {
            var viewModel = new TaxiListingViewModel
            {
                Taxies = this.taxiService.Overview(),
            };

            return this.View(viewModel);
        }
    }
}
