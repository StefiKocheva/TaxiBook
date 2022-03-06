namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaxiBook.Services.Interfaces;
    using TaxiBook.Services.ViewModels.Home;

    [Authorize]
    [Area("Manager")]
    public class HomeController : Controller
    {
        private readonly IFeedbackService feedbackService;

        public HomeController(IFeedbackService feedbackService) => this.feedbackService = feedbackService;

        [HttpGet]
        public IActionResult Index()
        {
            var model = new FeedbackListingViewModel();

            model.Feedbacks = this.feedbackService.All();

            return this.View(model);
        }
    }
}
