namespace TaxiBook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Feedbacks = new HashSet<Feedback>();
            this.Bookings = new HashSet<Booking>();
            this.TaxiDrivers = new HashSet<Taxi>();
        }

        public string Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public string? CardNumber { get; set; }

        public string TaxiId { get; set; }

        public Taxi Taxi { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public IEnumerable<Feedback> Feedbacks { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }

        public IEnumerable<Taxi> TaxiDrivers { get; set; }
    }
}
