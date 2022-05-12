namespace TaxiBook.Areas.Manager.ViewModels.Companies
{
    public class UpdateCompanyViewModel
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        // License

        public string Province { get; set; }

        public decimal? OneКilometerМileageDailyPrice { get; set; }

        public decimal? OneКilometerМileageNightPrice { get; set; }

        public decimal? DailyPricePerCall { get; set; }

        public decimal? NightPricePerCall { get; set; }

        public decimal? InitialDailyFee { get; set; }

        public decimal? InitialNightFee { get; set; }

        public decimal? DailyPricePerMinuteStay { get; set; }

        public decimal? NightPricePerMinuteStay { get; set; }
    }
}
