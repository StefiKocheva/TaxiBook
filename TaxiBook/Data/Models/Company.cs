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

            this.CreatedOn = DateTime.Now;

            this.Absences = new HashSet<Absence>();
            this.Orders = new HashSet<Order>();
            this.Employees = new HashSet<ApplicationUser>();
            this.Taxies = new HashSet<Taxi>();
            this.Feedbacks = new HashSet<Feedback>();
            this.WorkTimes = new HashSet<WorkTime>();
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

        public string Province { get; set; }

        public DateTime? CreatedOn { get; set; }

        //public string ProvinceId { get; set; }

        //[Required]
        //public virtual Address Province { get; set; }

        public Address Location { get; set; }

        [Required]
        public decimal? OneКilometerМileageDailyPrice { get; set; }

        [Required]
        public decimal? OneКilometerМileageNightPrice { get; set; }

        [Required]
        public decimal? DailyPricePerCall { get; set; }

        [Required]
        public decimal? NightPricePerCall { get; set; }

        [Required]
        public decimal? InitialDailyFee { get; set; }

        [Required]
        public decimal? InitialNightFee { get; set; }

        [Required]
        public decimal? DailyPricePerMinuteStay { get; set; }

        [Required]
        public decimal? NightPricePerMinuteStay { get; set; }

        public string LicenseUrl { get; set; }

        public virtual IEnumerable<Absence> Absences { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }

        public virtual IEnumerable<ApplicationUser> Employees { get; set; }

        public virtual IEnumerable<Taxi> Taxies { get; set; }

        public virtual IEnumerable<Feedback> Feedbacks { get; set; }

        public virtual IEnumerable<WorkTime> WorkTimes { get; set; }
    }
}
