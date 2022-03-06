namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IFeedbackService feedbackService;

        public HomeController(IFeedbackService feedbackService) => this.feedbackService = feedbackService;

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
        public ActionResult CompletedОrders()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult CreateFeedback(string userId)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedback(CreateFeedbackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var feedbackId = await this.feedbackService.CreateAsync(
                model.Company,
                model.IsLiked,
                model.Opinion);

            return this.RedirectToAction("CreateFeedback");
        }
    }
}
