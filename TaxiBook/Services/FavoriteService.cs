namespace TaxiBook.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class FavoriteService : IFavoriteService
    {
        private readonly TaxiBookDbContext db;
        
        public FavoriteService(TaxiBookDbContext db) 
            => this.db = db;

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

        public async void DeleteAsync(
            string id,
            string userId)
        {
            var favoriteCompany = await this.ByIdAndByUserId(id, userId);

            this.db.Favorites.Remove(favoriteCompany);

            await this.db.SaveChangesAsync();
        }

        private async Task<Favorite> ByIdAndByUserId(
            string id, 
            string userId)
            => await this.db
                .Favorites
                .Where(f => f.Id == id && f.ClientId == userId)
                .FirstOrDefaultAsync();
    }
}
