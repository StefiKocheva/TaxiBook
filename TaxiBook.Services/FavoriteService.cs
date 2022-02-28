namespace TaxiBook.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using ViewModels.Favorites;

    public class FavoriteService : IFavoriteService
    {
        private readonly TaxiBookDbContext db;
        
        public FavoriteService(TaxiBookDbContext db) => this.db = db;

        public async Task<string> AddAsync(string companyName)
        {
            var favorite = new Favorite()
            {
                CompanyName = companyName,
            };

            await db.Favorites.AddAsync(favorite);

            await db.SaveChangesAsync();

            return favorite.Id;
        }

        public async Task<IEnumerable<FavoriteListingViewModel>> AllAsync()
            => await this.db
                .Favorites
                .OrderBy(f => f.CompanyName)
                .Select(f => new FavoriteListingViewModel()
                {
                    Id = f.Id,
                    CompanyName = f.CompanyName,
                    DailyTariff = f.Client.Company.DailyTariff,
                    NightTariff = f.Client.Company.NightTariff,
                    PhoneNumber = f.Client.Company.PhoneNumber,
                    // Region = f.Client.Company.Address.Region,
                })
                .ToListAsync();

        public async void DeleteAsync(
            string id,
            string userId)
        {
            var favoriteCompany = await this.ByIdAndByUserId(id, userId);
            //if (favoriteCompany == null)
            //{
            //    Is it necessary to check if it's null?
            //}

            this.db.Favorites.Remove(favoriteCompany);

            await this.db.SaveChangesAsync();
        }

        private async Task<Favorite?> ByIdAndByUserId(
            string id, 
            string userId)
            => await this.db
                .Favorites
                .Where(f => f.Id == id && f.ClientId == userId)
                .FirstOrDefaultAsync();
    }
}
