namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IFeedbackService _service;

        public HomeController(IFeedbackService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult GiveFeedback(string userId)
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult CompletedОrders()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> GiveFeedback(GiveFeedbackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var feedbackId = await this._service.CreateAsync(
                model.Company,
                model.IsLiked,
                model.Description);

            return this.RedirectPermanent("GiveFeedback");
        }
    }
}
