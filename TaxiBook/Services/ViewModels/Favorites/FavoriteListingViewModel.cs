namespace TaxiBook.Services.ViewModels.Favorites
{
    using System.Collections.Generic;

    public class FavoriteListingViewModel
    {
        public IEnumerable<FavoriteDetailsModel> FavoriteCompanies { get; set; } = new HashSet<FavoriteDetailsModel>();
    }
}
