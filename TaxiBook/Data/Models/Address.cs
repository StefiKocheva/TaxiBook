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

            this.Taxies = new HashSet<Taxi>();
            this.CurrentLocations = new HashSet<Order>();
            this.EndLocations = new HashSet<Order>();
            //this.Provinces = new HashSet<Company>();
        }

        public string Id { get; set; }

        [MaxLength(500)]
        public string StartLocationCoordinates { get; set; }

        [Required]
        [MaxLength(500)]
        public string EndLocationCoordinates { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public virtual IEnumerable<Taxi> Taxies { get; set; }

        public virtual IEnumerable<Order> CurrentLocations { get; set; }

        public virtual IEnumerable<Order> EndLocations { get; set; }

        //public virtual IEnumerable<Company> Provinces { get; set; }
    }
}
