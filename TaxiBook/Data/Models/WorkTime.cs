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

        [Required]
        public string From { get; set; }

        [Required]
        public string Till { get; set; }

        public string EmployeeId { get; set; }

        public ApplicationUser Employee { get; set; }
    }
}
