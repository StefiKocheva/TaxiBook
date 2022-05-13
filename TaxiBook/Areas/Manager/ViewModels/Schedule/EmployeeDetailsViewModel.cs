using TaxiBook.Data.Models.Enums;

namespace TaxiBook.Areas.Manager.ViewModels.Schedule
{
    public class EmployeeDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public EmployeeRole EmployeeRole { get; set; }

        public string StartWork { get; set; }

        public string FinishWork { get; set; }
    }
}
