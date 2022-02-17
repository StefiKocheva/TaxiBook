namespace TaxiBook.Areas.TaxiDriver.ViewModels.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.ForthcomingАbsenceViewModel;

    public class ForthcomingАbsenceViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime From { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Till { get; set; }
    }
}
