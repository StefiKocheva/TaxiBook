namespace TaxiBook.Areas.Manager.Services.Inerfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models.Enums;
    using ViewModels.Employees;

    public interface IEmployeeService
    {
        Task<string> CreateAsync(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            EmployeeType employeeType,
            string numberPlate,
            string brand,
            string model);

        void UpdateAsync(
            string id, 
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber//,
            //string numberPlate,
            //string brand,
            /*string model*/);

        void DeleteAsync(string id);

        IEnumerable<EmployeeDetailsViewModel> All();
    }
}
