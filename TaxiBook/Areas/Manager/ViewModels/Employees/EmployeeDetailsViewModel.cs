namespace TaxiBook.Areas.Manager.ViewModels.Employees
{
    using Data.Models.Enums;

    public class EmployeeDetailsViewModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public EmployeeType EmployeeType { get; set; }
    }
}
