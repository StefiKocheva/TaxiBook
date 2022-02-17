namespace TaxiBook.Services
{
    using System.Threading.Tasks;
    using Interfaces;
    using Data;
    using Data.Models;

    public class FeedbackService : IFeedbackService
    {
        private readonly TaxiBookDbContext db;

        public FeedbackService(TaxiBookDbContext db)
        {
            this.db = db;
        }

        public async Task<string> GiveFeedbackAsync(string company, bool isLiked, string description)
        {
            var feedback = new Feedback
            {
                CompanyName = company,
                IsLiked = isLiked,
                Description = description,
            };

            await db.Feedbacks.AddAsync(feedback);

            await db.SaveChangesAsync();

            return feedback.Id;
        }
    }
}
