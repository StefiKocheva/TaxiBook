namespace TaxiBook.Areas.Manager.ViewModels.Schedule
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    using static Vallidation.AddEmployeeViewModel;

    public class AddEmployeeViewModel : Controller
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        // Enum
        public string Role { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        // DateTime?
        public string From { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        // DateTime?
        public string Till { get; set; }
    }
}
