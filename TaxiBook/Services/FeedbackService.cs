namespace TaxiBook.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TaxiBook.Infrastructure.Services;
    using ViewModels.Favorites;
    using ViewModels.Feedbacks;

    public class FeedbackService : IFeedbackService
    {
        private readonly TaxiBookDbContext db;
        private readonly ICurrentUserService currentUserService;

        public FeedbackService(
            TaxiBookDbContext db, 
            ICurrentUserService currentUserService)
        {
            this.db = db;
            this.currentUserService = currentUserService;
        }

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

        public IEnumerable<CompanyDetailsViewModel> OverviewCompanies()
            => this.db
            .Companies
            .OrderByDescending(c => c.Name)
            .Select(c => new CompanyDetailsViewModel()
            {
                Name = c.Name,
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
                ClientId = this.currentUserService.GetId(),
            };

            await db.Feedbacks.AddAsync(feedback);
            await db.SaveChangesAsync();

            var companyId = this.db
                .Companies
                .Where(c => c.Name == feedback.CompanyName)
                .Select(c => c.Id)
                .FirstOrDefault();

            feedback.CompanyId = companyId;

            await this.db.SaveChangesAsync();

            return feedback.Id;
        }

        public async void Delete(
            string id, 
            string clientId)
        {
            var feedback = await this.ByIdAndByUserId(id, clientId);

            this.db.Feedbacks.Remove(feedback);
            await this.db.SaveChangesAsync();
        }

        private async Task<Feedback> ByIdAndByUserId(
            string id, 
            string clientId)
           => await this.db
               .Feedbacks
               .Where(f => f.Id == id && f.ClientId == clientId)
               .FirstOrDefaultAsync();
    }
}
