namespace TaxiBook.Services.ViewModels.Favorites
{
    public class FavoriteListingViewModel
    {
        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string PhoneNumber { get; set; }

        public decimal DailyTariff { get; set; }

        public decimal NightTariff { get; set; }

        public string Region { get; set; }
    }
}
