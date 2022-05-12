namespace TaxiBook.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Infrastructure.Services;
    using Interfaces;
    using ViewModels.Favorites;

    public class FavoriteService : IFavoriteService
    {
        private readonly TaxiBookDbContext db;
        private readonly ICurrentUserService currentUserService;

        public FavoriteService(
            TaxiBookDbContext db, 
            ICurrentUserService currentUserService)
        {
            this.db = db;
            this.currentUserService = currentUserService;
        }

        public async Task<string> AddAsync(string companyName)
        {
            var favorite = new Favorite()
            {
                CompanyName = companyName,
                ClientId = this.currentUserService.GetId(),
            };

            var company = this.db
                .Companies
                .Where(c => c.Name == favorite.CompanyName)
                .Select(c => new FavoriteDetailsModel()
                {
                    OneКilometerМileageDailyPrice = c.OneКilometerМileageDailyPrice,
                    OneКilometerМileageNightPrice = c.OneКilometerМileageNightPrice,
                    Province = c.Province,
                    PhoneNumber = c.PhoneNumber,
                })
                .FirstOrDefault();

            favorite.OneКilometerМileageDailyPrice = company.OneКilometerМileageDailyPrice;
            favorite.OneКilometerМileageNightPrice = company.OneКilometerМileageNightPrice;
            favorite.Province = company.Province;
            favorite.PhoneNumber = company.PhoneNumber;

            await db.Favorites.AddAsync(favorite);
            await db.SaveChangesAsync();

            return favorite.Id;
        }

        public IEnumerable<CompanyDetailsViewModel> OverviewCompanies()
            => this.db
            .Companies
            .OrderByDescending(c => c.Name)
            .Select(c => new CompanyDetailsViewModel()
            {
                Name = c.Name,
            })
            .ToHashSet();

        public IEnumerable<FavoriteDetailsModel> OverviewFavoriteCompanies()
            => this.db
            .Favorites
            .OrderBy(c => c.CreatedOn)
            .Where(c => c.ClientId == this.currentUserService.GetId())
            .Select(c => new FavoriteDetailsModel()
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                OneКilometerМileageDailyPrice = c.OneКilometerМileageDailyPrice,
                OneКilometerМileageNightPrice = c.OneКilometerМileageNightPrice,
                Province = c.Province,
                PhoneNumber = c.PhoneNumber,
            })
            .ToHashSet();

        public async Task DeleteAsync(string id)
        {
            var clientId = this.currentUserService.GetId();
            var favoriteCompany = this.ByIdAndByUserId(id, clientId);

            this.db.Favorites.Remove(favoriteCompany);

            await this.db.SaveChangesAsync();
        }

        private Favorite ByIdAndByUserId(
            string id, 
            string userId)
            => this.db
                .Favorites
                .Where(f => f.Id == id && f.ClientId == userId)
                .FirstOrDefault();

    }
}
