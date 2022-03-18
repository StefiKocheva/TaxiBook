namespace TaxiBook.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Favorites;

    public interface IFavoriteService
    {
        Task<string> AddAsync(string companyName);

        IEnumerable<CompanyDetailsViewModel> OverviewCompanies();

        IEnumerable<FavoriteDetailsModel> OverviewFavoriteCompanies();

        void DeleteAsync(
            string id, 
            string userId);
    }
}
