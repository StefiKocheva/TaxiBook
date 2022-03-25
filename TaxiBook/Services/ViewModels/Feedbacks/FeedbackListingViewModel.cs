namespace TaxiBook.Services.ViewModels.Feedbacks
{
    using System.Collections.Generic;

    public class FeedbackListingViewModel
    {
        public IEnumerable<FeedbackDetailsViewModel> Feedbacks { get; set; }

        public CreateFeedbackViewModel CreateFeedbackViewModel { get; set; }
    }
}
