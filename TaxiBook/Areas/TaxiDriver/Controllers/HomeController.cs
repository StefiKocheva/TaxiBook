namespace TaxiBook.Areas.TaxiDriver.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Inerfaces;
    using ViewModels.Home;

    [Authorize]
    [Area("TaxiDriver")]
    public class HomeController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public HomeController(IScheduleService scheduleService) => this._scheduleService = scheduleService;


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
        
           // var forthcomingAbsenceId = await this._homeService.ForthcomingАbsenceAsync(
                //model.From,
                //model.Till);
        
            return this.RedirectPermanent("Schedule");
        }
    }
}
