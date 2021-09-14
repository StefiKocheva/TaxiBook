namespace TaxiBook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Taxi
    {
        public Taxi()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Users = new HashSet<ApplicationUser>();
        }

        public string Id { get; set; }

        [Required]
        public bool IsBusy { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public string TaxiDriverId { get; set; }

        public ApplicationUser TaxiDriver { get; set; }

        public string LocationId { get; set; }

        public Address Location { get; set; }

        [Required]
        public string WorkTime { get; set; }

        [Required]
        public decimal PricePerKilometer { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}
