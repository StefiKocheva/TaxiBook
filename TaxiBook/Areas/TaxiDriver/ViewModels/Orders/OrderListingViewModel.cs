namespace TaxiBook.Areas.TaxiDriver.ViewModels.Orders
{
    using System.Collections.Generic;

    public class OrderListingViewModel
    {
        public IEnumerable<OrderDetailsViewModel> UnacceptedOrders { get; set; } = new HashSet<OrderDetailsViewModel>();

        public IEnumerable<OrderDetailsViewModel> RefusedOrders { get; set; } = new HashSet<OrderDetailsViewModel>();

        public IEnumerable<OrderDetailsViewModel> AcceptedOrders { get; set; } = new HashSet<OrderDetailsViewModel>();
    }
}
