namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Services.Interfaces;
    using Services.ViewModels.Feedbacks;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "Client")]
    public class FeedbacksController : Controller
    {
        private readonly IFeedbackService feedbackService;

        public FeedbacksController(IFeedbackService feedbackService) 
            => this.feedbackService = feedbackService;

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeedbackViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.feedbackService.CreateAsync(
                viewModel.Company,
                viewModel.IsLiked,
                viewModel.Opinion);

            return this.RedirectToAction("Create");
        }
    }
}
