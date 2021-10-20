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

        public virtual Address CurrentLocation { get; set; }

        public string EndLocationId { get; set; }

        public virtual Address EndLocation { get; set; }

        public string ClientId { get; set; }

        public virtual ApplicationUser Client { get; set; }

        public string TaxiId { get; set; }

        public virtual Taxi Taxi { get; set; }
    }
}
