namespace TaxiBook.Areas.Manager.ViewModels.Schedule
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class AddEmployeeViewModel : Controller
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        // Enum
        public string Role { get; set; }

        [Required]
        // DateTime?
        public string From { get; set; }

        [Required]
        // DateTime?
        public string Till { get; set; }
    }
}
