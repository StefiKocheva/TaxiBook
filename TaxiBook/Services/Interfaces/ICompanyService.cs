namespace TaxiBook.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Companies;

    public interface ICompanyService
    {
        IEnumerable<CompanyDetailsViewModel> All();

        Task<string> CreateAsync(
            string name,
            string phoneNumber,
            string description,
            //IFormFile license,
            string province,
            decimal? oneКilometerМileageDailyPrice,
            decimal? oneКilometerМileageNightPrice,
            decimal? dailyPricePerCall,
            decimal? nightPricePerCall,
            decimal? initialDailyFee,
            decimal? initialNightFee,
            decimal? dailyPricePerMinuteStay,
            decimal? nightPricePerMinuteStay);
    }
}
