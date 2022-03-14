namespace TaxiBook.Services.ViewModels.Orders
{
    using System.Collections.Generic;

    public class OrderListingViewModel
    {
        public IEnumerable<OrderDetailsViewModel> Orders { get; set; }
    }
}
