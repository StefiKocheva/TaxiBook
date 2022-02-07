namespace TaxiBook.Areas.TaxiDriver.ViewModels.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ForthcomingАbsenceViewModel
    {
        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime Till { get; set; }
    }
}
