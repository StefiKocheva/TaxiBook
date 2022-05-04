namespace TaxiBook.Areas.Dispatcher.ViewModels.Orders
{
    using System.Collections.Generic;

    public class ListingViewModel
    {
        public IEnumerable<DriverDetailsViewModel> AvailableDrivers { get; set; } = new HashSet<DriverDetailsViewModel>();

        public CreateOrderViewModel CreateOrderViewModel { get; set; }
    }
}
