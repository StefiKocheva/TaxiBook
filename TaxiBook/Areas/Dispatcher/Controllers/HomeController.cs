namespace TaxiBook.Areas.Dispatcher.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using ViewModels.Home;

    [Authorize]
    [Area("Dispatcher")]
    public class HomeController : Controller
    {
        private readonly IScheduleService _homeService;

        public HomeController(IScheduleService homeService)
        {
            this._homeService = homeService;
        }

        [HttpGet]
        public IActionResult Schedule()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Schedule(ForthcomingАbsenceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
        
            var forthcomingAbsenceId = await this._homeService.CreateАbsenceAsync(
                model.From,
                model.Till);
        
            return this.RedirectPermanent("Schedule");
        }

        [HttpGet]
        public IActionResult Track(string orderId)
        {
            return this.View();
        }
    }
}
