using System.Collections.Generic;
using TaxiBook.Services.ViewModels.Companies;

namespace TaxiBook.Services.ViewModels.Favorites
{
    public class FavoriteListingViewModel
    {
        public IEnumerable<FavoriteDetailsModel> FavoriteCompanies { get; set; } = new HashSet<FavoriteDetailsModel>();
    }
}
