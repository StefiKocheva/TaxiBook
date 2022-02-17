namespace TaxiBook.Areas.Dispatcher.ViewModels.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.ForthcomingАbsenceViewModel;

    public class ForthcomingАbsenceViewModel 
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        // From today due current year [Range(DateTime.UtcNow.Date, DateTime.UtcNow.Year)]
        public DateTime From { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Till { get; set; }
    }
}
