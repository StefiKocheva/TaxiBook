namespace TaxiBook.Areas.Manager.ViewModels.Employees
{
    using Data.Models.Enums;

    public class UpdateEmployeeViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public EmployeeRole EmployeeRole { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string NumberPlate { get; set; }
    }
}
