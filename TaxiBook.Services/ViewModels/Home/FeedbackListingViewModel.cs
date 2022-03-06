namespace TaxiBook.Services.ViewModels.Home
{
    using System.Collections.Generic;

    public class FeedbackListingViewModel
    {
        public IEnumerable<FeedbackDetailsViewModel> Feedbacks { get; set; }
    }
}
