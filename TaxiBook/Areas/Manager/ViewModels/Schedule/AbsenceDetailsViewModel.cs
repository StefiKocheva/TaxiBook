namespace TaxiBook.Areas.Manager.ViewModels.Schedule
{
    using System;
    using TaxiBook.Data.Models.Enums;

    public class AbsenceDetailsViewModel
    {
        public string Id { get; set; }

        public EmployeeRole Role { get; set; }

        public string FullName { get; set; }

        public string From { get; set; }

        public string Till { get; set; }
    }
}
