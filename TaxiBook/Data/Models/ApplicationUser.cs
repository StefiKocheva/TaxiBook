﻿using Microsoft.AspNetCore.Identity;

namespace TaxiBook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            
            this.Feedbacks = new HashSet<Feedback>();
            this.Bookings = new HashSet<Booking>();
            this.Taxies = new HashSet<Taxi>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual IEnumerable<Feedback> Feedbacks { get; set; }

        public virtual IEnumerable<Booking> Bookings { get; set; }

        public virtual IEnumerable<Taxi> Taxies { get; set; }
    }
}
