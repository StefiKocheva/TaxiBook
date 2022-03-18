namespace TaxiBook.Areas.Dispatcher.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using ViewModels.Home;

    [Authorize(Roles = "Dispatcher")]
    [Area("Dispatcher")]
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

        [HttpGet]
        public IActionResult Track()
        {
            return this.View();
        }
    }
}
