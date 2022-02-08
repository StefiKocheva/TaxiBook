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
            this.Bookings = new HashSet<Booking>();
        }

        public string Id { get; set; }
        
        public bool IsBusy { get; set; }

        [Required]
        public string NumberPlate { get; set; }

        [Required]
        public string BrandAndModel { get; set; }

        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public string DriverId { get; set; }

        public virtual ApplicationUser Driver { get; set; }

        public string LocationId { get; set; }

        public virtual Address Location { get; set; }

        public virtual IEnumerable<ApplicationUser> Users { get; set; }

        public virtual IEnumerable<Booking> Bookings { get; set; }
    }
}
