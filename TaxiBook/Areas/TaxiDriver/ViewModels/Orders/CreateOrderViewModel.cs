namespace TaxiBook.Areas.TaxiDriver.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        public string CurrentLocation { get; set; }

        public string CurrentLocationDetails { get; set; }

        public string EndLocation { get; set; }

        public string EndLocationDetails { get; set; }

        public int CountOfPassengers { get; set; }

        public string AdditionalRequirements { get; set; }
    }
}
