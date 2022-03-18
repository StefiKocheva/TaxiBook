namespace TaxiBook.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Orders;

    public interface IOrderService
    {
        Task<string> CreateAsync(
            string currentLocation, 
            string currentLocationDetails, 
            string endLocation, 
            string endLocationDetails, 
            int countOfPassengers, 
            string additionalRequirements);

        void DeleteAsync(
            string id, 
            string clientId);

        Task<OrderDetailsViewModel> DetailsAsync(string id);

        IEnumerable<OrderDetailsViewModel> Overview();

        IEnumerable<OrderDetailsViewModel> OverviewPast();
    }
}
