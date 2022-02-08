namespace TaxiBook.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Schedule
    {
        public Schedule()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string StartAt { get; set; }

        [Required]
        public string FinishAt { get; set; }

        public string EmployeeId { get; set; }
        
        public virtual ApplicationUser Employee { get; set; }
    }
}
