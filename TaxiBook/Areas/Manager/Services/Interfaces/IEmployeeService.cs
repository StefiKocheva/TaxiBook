namespace TaxiBook.Areas.Manager.Services.Inerfaces
{
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        Task<string> CreateAsync(string firstName, string lastName, string placeOfResidence, string email, string phoneNumber);
    }
}
