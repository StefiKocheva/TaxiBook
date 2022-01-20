namespace TaxiBook.Areas.Dispatcher.ViewModels.Orders
{
    using Microsoft.AspNetCore.Mvc;

    public class CreateOrderViewModel
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string CurrentLocation { get; set; }

        public string CurrentLocationDetails { get; set; }

        public string EndLocation { get; set; }

        public string EndLocationDetails { get; set; }

        public int CountOfPassengers { get; set; }

        public string AdditionalRequirements { get; set; }

        public string TaxiDriverName { get; set; }
    }
}
