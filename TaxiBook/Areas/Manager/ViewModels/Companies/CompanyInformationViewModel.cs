using System.Collections.Generic;
using TaxiBook.Data.Models;

namespace TaxiBook.Areas.Manager.ViewModels.Companies
{
    public class CompanyInformationViewModel 
    {
        public string Id { get; set; }

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

        public UpdateCompanyViewModel UpdateCompanyViewModel { get; set; }

        public int? CountOfDispatchers { get; set; }

        public int? CountOfTaxiDrivers { get; set; }
    }
}
