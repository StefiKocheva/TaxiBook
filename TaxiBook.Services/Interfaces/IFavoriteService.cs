namespace TaxiBook.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Favorites;

    public interface IFavoriteService
    {
        //Task<IEnumerable<FavoriteListingViewModel>> AllAsync();

        Task<string> AddAsync(string companyName);

        void DeleteAsync(
            string id, 
            string userId);
    }
}
