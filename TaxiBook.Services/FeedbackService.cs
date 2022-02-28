﻿namespace TaxiBook.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TaxiBook.Services.ViewModels.Home;

    public class FeedbackService : IFeedbackService
    {
        private readonly TaxiBookDbContext db;

        public FeedbackService(TaxiBookDbContext db) => this.db = db;

        public async Task<IEnumerable<FeedbackListingViewModel>> All()
            => await this.db
                .Feedbacks
                .OrderByDescending(f => f.CreatedOn)
                .Select(f => new FeedbackListingViewModel()
                {
                    Id = f.Id,
                    ClientName = f.Client.FirstName + " " + f.Client.LastName,
                    IsLiked = f.IsLiked,
                    Description = f.Description,
                })
                .ToListAsync();

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

        private async Task<Feedback?> ByIdAndByUserId(
            string id, 
            string userId)
           => await this.db
               .Feedbacks
               .Where(f => f.Id == id && f.ClientId == userId)
               .FirstOrDefaultAsync();
    }
}
