﻿namespace TaxiBook.Services
{
    using System.Threading.Tasks;
    using Interfaces;
    using Data;
    using Data.Models;

    public class FavoriteService : IFavoriteService
    {
        private readonly TaxiBookDbContext db;
        
        public FavoriteService(TaxiBookDbContext db)
        {
            this.db = db;
        }

        public async Task<string> CreateAsync(string companyName)
        {
            var favorite = new Favorite()
            {
                CompanyName = companyName,
            };

            await db.Favorites.AddAsync(favorite);

            await db.SaveChangesAsync();

            return favorite.Id;
        }
    }
}
