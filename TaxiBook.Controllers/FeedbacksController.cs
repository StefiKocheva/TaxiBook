namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TaxiBook.Services.Interfaces;
    using TaxiBook.Services.ViewModels.Feedbacks;

    public class FeedbacksController : Controller
    {
        private readonly IFeedbackService feedbackService;

        public FeedbacksController(IFeedbackService feedbackService) => this.feedbackService = feedbackService;

        [HttpGet]
        public ActionResult Create(string userId)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeedbackViewModel model)
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
