namespace TaxiBook.Areas.TaxiDriver.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    [Authorize]
    [Area("TaxiDriver")]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
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
    }
}
