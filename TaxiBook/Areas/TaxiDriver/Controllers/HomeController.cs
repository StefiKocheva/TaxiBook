namespace TaxiBook.Areas.TaxiDriver.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Inerfaces;
    using System.Threading.Tasks;
    using ViewModels.Home;

    [Authorize]
    [Area("TaxiDriver")]
    public class HomeController : Controller
    {
        private readonly IScheduleService _homeService;

        public HomeController(IScheduleService homeService)
        {
            this._homeService = homeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
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
        
            var forthcomingAbsenceId = await this._homeService.ForthcomingАbsenceAsync(
                model.From,
                model.Till);
        
            return this.RedirectPermanent("Schedule");
        }
    }
}
