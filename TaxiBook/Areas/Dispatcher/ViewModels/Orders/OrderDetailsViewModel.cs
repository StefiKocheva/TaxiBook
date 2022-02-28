namespace TaxiBook.Areas.Dispatcher.ViewModels.Orders
{
    public class OrderDetailsViewModel
    {
        public string Id { get; set; }

        public string ClientName { get; set; }

        public string CreatorId { get; set; }

        public string PhoneNumber { get; set; }

        public string CurrentLocation { get; set; }

        public string EndLocation { get; set; }

        public string CurrentLocationDetails { get; set; }

        public string EndLocationDetails { get; set; }

        public int CountOfPassengers { get; set; }

        public string AdditionalRequirements { get; set; }
    }
}
