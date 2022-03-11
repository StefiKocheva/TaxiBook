namespace TaxiBook.Areas.TaxiDriver.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Inerfaces;
    using ViewModels.Home;

    [Authorize(Roles = "TaxiDriver")]
    [Area("TaxiDriver")]
    public class HomeController : Controller
    {
        private readonly IScheduleService scheduleService;

        public HomeController(IScheduleService scheduleService) 
            => this.scheduleService = scheduleService;


        [HttpGet]
        public IActionResult Schedule()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Schedule(CreateАbsenceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.scheduleService.CreateАbsenceAsync(
                viewModel.From,
                viewModel.Till);

            return this.RedirectToAction("Schedule");
        }
    }
}
