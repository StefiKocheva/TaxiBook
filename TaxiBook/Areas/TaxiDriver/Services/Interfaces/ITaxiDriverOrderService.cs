namespace TaxiBook.Areas.TaxiDriver.Services.Inerfaces
{
    using System.Threading.Tasks;

    public interface ITaxiDriverOrderService
    {
        Task<string> CreateAsync(string currentLocation, string currentLocationDetails, string endLocation, string endLocationDetails, int countOfPassengers, string additionalRequirements);
    }
}
