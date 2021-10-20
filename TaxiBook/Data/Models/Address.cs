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
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Coordinates { get; set; }

        public virtual IEnumerable<Company> Companies { get; set; }

        public virtual IEnumerable<Taxi> Taxies { get; set; }

        public virtual IEnumerable<Booking> CurrentLocations { get; set; }

        public virtual IEnumerable<Booking> EndLocations { get; set; }
    }
}
