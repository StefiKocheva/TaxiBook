namespace TaxiBook.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaxiBook.Services.ViewModels.Feedbacks;

    public interface IFeedbackService
    {
        Task<string> CreateAsync(
            string company, 
            bool isLiked, 
            string description);

        void Delete(string id, string userId);

        IEnumerable<FeedbackDetailsViewModel> All();
    }
}
