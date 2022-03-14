namespace TaxiBook.Areas.Manager.Services.Inerfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaxiBook.Data.Models.Enums;
    using ViewModels.Employees;

    public interface IEmployeeService
    {
        Task<string> CreateAsync(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            EmployeeRole employeeRole,
            string numberPlate,
            string brand,
            string model);

        Task<string> UpdateAsync(
            string id, 
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber,
            string numberPlate,
            string brand,
            string model);

        void DeleteAsync(string id);

        IEnumerable<EmployeeDetailsViewModel> All();

        //IEnumerable<EmployeeDetailsViewModel> Details(string id);
    }
}
