namespace TaxiBook.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Favorites;
    using ViewModels.Feedbacks;

    public interface IFeedbackService
    {
        Task<string> CreateAsync(
            string company, 
            bool isLiked, 
            string description);

        IEnumerable<CompanyDetailsViewModel> OverviewCompanies();

        void Delete(string id, string userId);

        IEnumerable<FeedbackDetailsViewModel> All();
    }
}
