namespace TaxiBook.Services.ViewModels.Feedbacks
{
    using System.Collections.Generic;
    using Favorites;

    public class ListingViewModel
    {
        public IEnumerable<CompanyDetailsViewModel> AllCompanies { get; set; } = new HashSet<CompanyDetailsViewModel>();

        public CreateFeedbackViewModel CreateFeedbackViewModel { get; set; }
    }
}
