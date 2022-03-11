namespace TaxiBook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;
    using Microsoft.AspNetCore.Identity;

    using static Vallidation.ApplicationUser;

    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();

            this.CreatedOn = DateTime.Now;

            this.Feedbacks = new HashSet<Feedback>();
            this.Orders = new HashSet<Order>();
            this.Taxies = new HashSet<Taxi>();
            this.Absences = new HashSet<Absence>();
            this.Favorites = new HashSet<Favorite>();
            this.WorkTimes = new HashSet<WorkTime>();
        }

        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }

        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ImageUrl { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public Address Address { get; set; }

        public Schedule Schedule { get; set; }

        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual IEnumerable<Feedback> Feedbacks { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }

        public virtual IEnumerable<Taxi> Taxies { get; set; }

        public virtual IEnumerable<Absence> Absences { get; set; }

        public virtual IEnumerable<Favorite> Favorites { get; set; }

        public virtual IEnumerable<WorkTime> WorkTimes { get; set; }
    }
}
