namespace TaxiBook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Companies = new HashSet<Company>();
            this.Taxies = new HashSet<Taxi>();
            this.CurrentLocations = new HashSet<Booking>();
            this.EndLocations = new HashSet<Booking>();
            this.TaxiesLocation = new HashSet<Taxi>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Coordinates { get; set; }

        public IEnumerable<Company> Companies { get; set; }

        public IEnumerable<Taxi> Taxies { get; set; }

        public IEnumerable<Booking> CurrentLocations { get; set; }

        public IEnumerable<Booking> EndLocations { get; set; }

        public IEnumerable<Taxi> TaxiesLocation { get; set; }
    }
}
