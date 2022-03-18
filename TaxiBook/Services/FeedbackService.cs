namespace TaxiBook.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using TaxiBook.Services.ViewModels.Favorites;
    using ViewModels.Feedbacks;

    public class FeedbackService : IFeedbackService
    {
        private readonly TaxiBookDbContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public FeedbackService(
            TaxiBookDbContext db, 
            IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
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
            var userName = this.httpContextAccessor.HttpContext.User.Identity.Name;
            var user = this.db.Users.FirstOrDefault(x => x.UserName == userName);

            var feedback = new Feedback
            {
                CompanyName = company,
                IsLiked = isLiked,
                Description = description,
                ClientId = user.Id,
            };

            await db.Feedbacks.AddAsync(feedback);

            await db.SaveChangesAsync();

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
