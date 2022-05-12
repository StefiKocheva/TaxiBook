namespace TaxiBook.Areas.TaxiDriver.Services.Interfaces
{
    using System.Threading.Tasks;
    using ViewModels.Taxies;

    public interface ITaxiService
    {
        Task<TaxiInformationViewModel> OverviewAsync();

        Task EditAsync(
            string brand, 
            string model, 
            string numberPlate);
    }
}
