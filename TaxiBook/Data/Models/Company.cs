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
            this.Users = new HashSet<ApplicationUser>();
            this.Taxies = new HashSet<Taxi>();
        }

        public string Id { get; set; }


        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string AddressId { get; set; }

        public Address Address { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }

        public IEnumerable<Taxi> Taxies { get; set; }
    }
}
