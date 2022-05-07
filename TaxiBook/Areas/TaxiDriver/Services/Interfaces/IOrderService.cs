namespace TaxiBook.Areas.TaxiDriver.Services.Inerfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Orders;

    public interface IOrderService
    {
        Task<string> CreateAsync(
            string endLocation,
            int countOfPassengers);

        IEnumerable<OrderDetailsViewModel> GetAllUnacceptedOrders();

        void AcceptAsync(string id);

        IEnumerable<OrderDetailsViewModel> GetAllAcceptedOrders();

        Task<OrderDetailsViewModel> DetailsAsync(string id);

        IEnumerable<OrderDetailsViewModel> GetAllRefusedOrders();

        Task<OrderDetailsViewModel> OverviewAsync();
    }
}
