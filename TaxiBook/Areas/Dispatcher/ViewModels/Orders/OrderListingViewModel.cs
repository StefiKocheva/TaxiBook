namespace TaxiBook.Areas.Dispatcher.ViewModels.Orders
{
    using System.Collections.Generic;

    public class OrderListingViewModel
    {
        public IEnumerable<OrderDetailsViewModel> UnprocessedOrders { get; set; } = new HashSet<OrderDetailsViewModel>();
        
        public IEnumerable<OrderDetailsViewModel> RefusedOrders { get; set; } = new HashSet<OrderDetailsViewModel>();
        
        public IEnumerable<OrderDetailsViewModel> ProcessedOrders { get; set; } = new HashSet<OrderDetailsViewModel>();
    }
}
