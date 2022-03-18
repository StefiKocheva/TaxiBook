namespace TaxiBook.Services.ViewModels.Favorites
{
    using System.Collections.Generic;

    public class ListingViewModel
    {
        public IEnumerable<CompanyDetailsViewModel> AllCompanies { get; set; } = new HashSet<CompanyDetailsViewModel>();

        public IEnumerable<FavoriteDetailsModel> FavoriteCompanies { get; set; } = new HashSet<FavoriteDetailsModel>();

        public CreateFavoriteViewModel CreateFavoriteViewModel { get; set; }
    }
}
