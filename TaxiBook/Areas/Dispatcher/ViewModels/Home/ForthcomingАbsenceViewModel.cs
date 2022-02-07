namespace TaxiBook.Areas.Dispatcher.ViewModels.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ForthcomingАbsenceViewModel 
    {
        [Required]
        // From today due current year [Range(DateTime.UtcNow.Date, DateTime.UtcNow.Year)]
        public DateTime From { get; set; }

        [Required]
        public DateTime Till { get; set; }
    }
}
