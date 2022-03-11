namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaxiBook.Services.Interfaces;
    using TaxiBook.Services.ViewModels.Feedbacks;

    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class FeedbacksController : Controller
    {
        private readonly IFeedbackService feedbackService;

        public FeedbacksController(IFeedbackService feedbackService)
            => this.feedbackService = feedbackService;

        [HttpGet]
        public IActionResult All()
        {
            var model = new FeedbackListingViewModel();

            model.Feedbacks = this.feedbackService.All();

            return this.View(model);
        }
    }
}
