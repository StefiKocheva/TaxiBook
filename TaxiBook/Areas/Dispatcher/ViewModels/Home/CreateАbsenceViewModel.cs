namespace TaxiBook.Areas.Dispatcher.ViewModels.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.ForthcomingАbsenceViewModel;

    public class CreateАbsenceViewModel 
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        //[Range(DateTime.Now.Date.Day, DateTime.Now.Year)]
        public string From { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Till { get; set; }
    }
}
