namespace TaxiBook.Areas.TaxiDriver.Services.Inerfaces
{
    using System.Threading.Tasks;
    using ViewModels.Orders;

    public interface IOrderService
    {
        Task<string> CreateAsync(
            string endLocation,
            int countOfPassengers);

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
