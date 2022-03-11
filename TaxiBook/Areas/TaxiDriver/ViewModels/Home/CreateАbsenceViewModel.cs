namespace TaxiBook.Areas.TaxiDriver.ViewModels.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.ForthcomingАbsenceViewModel;

    public class CreateАbsenceViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string From { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Till { get; set; }
    }
}
