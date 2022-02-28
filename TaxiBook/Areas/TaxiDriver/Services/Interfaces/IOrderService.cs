namespace TaxiBook.Areas.TaxiDriver.Services.Inerfaces
{
    using System.Threading.Tasks;
    using TaxiBook.Areas.TaxiDriver.ViewModels.Orders;

    public interface IOrderService
    {
        Task<string> CreateAsync(
            string currentLocation, 
            string currentLocationDetails, 
            string endLocation, string 
            endLocationDetails, 
            int countOfPassengers, 
            string additionalRequirements);

        void UpdateAsync(
            string id,
            string name,
            string phoneNumber,
            string currentLocation,
            string currentLocationDetails,
            string endLocation,
            string endLocationDetails,
            int countOfPassengers,
            string additionalRequirements,
            string userId);

        Task<OrderDetailsViewModel> DetailsAsync(string id);
    }
}
