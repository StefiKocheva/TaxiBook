namespace TaxiBook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Employees = new HashSet<ApplicationUser>();
            this.Taxies = new HashSet<Taxi>();
        }

        public string Id { get; set; }


        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string LicenseUrl { get; set; }

        [Required]
        public decimal PricePerKilometer { get; set; }

        public virtual IEnumerable<ApplicationUser> Employees { get; set; }

        public virtual IEnumerable<Taxi> Taxies { get; set; }
    }
}
