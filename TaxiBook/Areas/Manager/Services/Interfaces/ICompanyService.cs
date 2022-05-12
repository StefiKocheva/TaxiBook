namespace TaxiBook.Areas.Manager.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Companies;

    public interface ICompanyService
    {
        Task<CompanyInformationViewModel> OverviewAsync();

        Task EditAsync(
            string id,
            string name,
            string phoneNumber,
            string description,
            string province,
            decimal? OneКilometerМileageDailyPrice,
            decimal? DailyPricePerCall,
            decimal? InitialDailyFee,
            decimal? DailyPricePerMinuteStay,
            decimal? OneКilometerМileageNightPrice,
            decimal? NightPricePerCall,
            decimal? InitialNightFee,
            decimal? NightPricePerMinuteStay);
    }
}
