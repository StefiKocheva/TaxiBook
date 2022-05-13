namespace TaxiBook.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class WorkTime
    {
        public WorkTime()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public int? Day { get; set; }

        public int? Month { get; set; }

        public int? Year { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string Till { get; set; }

        public string EmployeeId { get; set; }

        public ApplicationUser Employee { get; set; }

        public string Companyid { get; set; }

        public Company Company { get; set; }
    }
}
