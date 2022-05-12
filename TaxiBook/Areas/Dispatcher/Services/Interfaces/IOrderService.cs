namespace TaxiBook.Areas.Dispatcher.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Orders;

    public interface IOrderService
    {
        Task<string> CreateAsync(
            string name, 
            string phoneNumber, 
            string currentLocation, 
            string currentLocationDetails,
            string endLocation, 
            string endLocationDetails, 
            int? countOfPassengers, 
            string additionalRequirements, 
            string taxiDriverName);

        IEnumerable<OrderDetailsViewModel> GetAllUnprocessedOrders();

        IEnumerable<OrderDetailsViewModel> GetAllProcessedOrders();

        IEnumerable<OrderDetailsViewModel> GetAllRefusedOrders();

        IEnumerable<DriverDetailsViewModel> GetAvailableDriversDetails();

        Task UnacceptAsync(string id);

        Task ProcessAsync(string id);

        Task<OrderDetailsViewModel> DetailsAsync(string id);
    }
}
