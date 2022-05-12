using System;

namespace TaxiBook.Areas.TaxiDriver.ViewModels.Orders
{
    public class OrderDetailsViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string StartLocation { get; set; }

        public string EndLocation { get; set; }

        public string StartLocationDetails { get; set; }

        public string EndLocationDetails { get; set; }

        public int? CountOfPassengers { get; set; }

        public string AdditionalRequirements { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? CompletedOn { get; set; }
    }
}
