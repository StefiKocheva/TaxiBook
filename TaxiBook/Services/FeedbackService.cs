namespace TaxiBook.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using ViewModels.Feedbacks;

    public class FeedbackService : IFeedbackService
    {
        private readonly TaxiBookDbContext db;

        public FeedbackService(TaxiBookDbContext db) 
            => this.db = db;

        public IEnumerable<FeedbackDetailsViewModel> All()
            => this.db
                .Feedbacks
                .OrderByDescending(f => f.CreatedOn)
                .Select(f => new FeedbackDetailsViewModel()
                {
                    Id = f.Id,
                    ClientName = f.Client.FirstName + " " + f.Client.LastName,
                    IsLiked = f.IsLiked,
                    Opinion = f.Description,
                })
                .ToHashSet();

        public async Task<string> CreateAsync(
            string company, 
            bool isLiked, 
            string description)
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

        public async void Delete(
            string id, 
            string userId)
        {
            var feedback = await this.ByIdAndByUserId(id, userId);
            //if (order == null)
            //{
            //    Is it necessary to check if it's null?
            //}

            this.db.Feedbacks.Remove(feedback);

            await this.db.SaveChangesAsync();
        }

        private async Task<Feedback> ByIdAndByUserId(
            string id, 
            string userId)
           => await this.db
               .Feedbacks
               .Where(f => f.Id == id && f.ClientId == userId)
               .FirstOrDefaultAsync();
    }
}
