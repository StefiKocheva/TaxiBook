namespace TaxiBook.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Absence
    {
        public Absence()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string Till { get; set; }

        public bool IsApproved { get; set; }

        public string EmployeeId { get; set; }

        public ApplicationUser Employee { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
