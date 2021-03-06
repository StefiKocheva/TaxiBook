namespace TaxiBook.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Orders;

    public interface IOrderService
    {
        Task<string> CreateAsync(
            string companyId,
            string currentLocation, 
            string currentLocationDetails, 
            string endLocation, 
            string endLocationDetails, 
            int countOfPassengers, 
            string additionalRequirements);

        void Refuse(string id);

        Task<OrderDetailsViewModel> DetailsAsync(string id);

        IEnumerable<OrderDetailsViewModel> Overview();

        IEnumerable<OrderDetailsViewModel> OverviewPast();
    }
}
