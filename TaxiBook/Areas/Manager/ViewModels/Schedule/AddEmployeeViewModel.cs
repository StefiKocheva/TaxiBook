namespace TaxiBook.Areas.Manager.ViewModels.Schedule
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    using static Vallidation.AddEmployeeViewModel;

    public class AddEmployeeViewModel : Controller
    {

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string From { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Till { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Name { get; set; }

        public IEnumerable<EmployeeInformationViewModel> Employees { get; set; } = new HashSet<EmployeeInformationViewModel>();
    }
}
