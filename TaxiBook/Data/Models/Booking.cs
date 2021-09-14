namespace TaxiBook.Data.Models
{
    using System;
    public class Booking
    {
        public Booking()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string CurrentLocationId { get; set; }

        public Address CurrentLocation { get; set; }

        public string EndLocationId { get; set; }

        public Address EndLocation { get; set; }

        public string ClientId { get; set; }

        public ApplicationUser Client { get; set; }
    }
}
