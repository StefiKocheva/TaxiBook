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
        [Phone]
        public string PhoneNumber { get; set; }

        public string AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual IEnumerable<ApplicationUser> Employees { get; set; }

        public virtual IEnumerable<Taxi> Taxies { get; set; }
    }
}
