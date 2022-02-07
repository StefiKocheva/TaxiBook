namespace TaxiBook.Areas.Dispatcher.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    [Authorize]
    [Area("Dispatcher")]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            this._homeService = homeService;
        }

        [HttpGet]
        public IActionResult Schedule()
        {
            return this.View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Schedule(ForthcomingАbsenceViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return this.BadRequest();
        //    }
        //
        //    //var forthcomingAbsenceId = await this._homeService.ForthcomingАbsenceAsync(
        //    //    );
        //
        //    return this.RedirectPermanent("Schedule");
        //}

        [HttpGet]
        public IActionResult Track()
        {
            return this.View();
        }
    }
}
