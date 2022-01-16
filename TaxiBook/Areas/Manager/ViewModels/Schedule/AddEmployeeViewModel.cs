namespace TaxiBook.Areas.Manager.ViewModels.Schedule
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class AddEmployeeViewModel : Controller
    {
        public string FullName { get; set; }

        // Enum
        public string Position { get; set; }

        public DateTime From { get; set; }

        public DateTime Till { get; set; }
    }
}
