namespace TaxiBook.Services
{
    using System.Threading.Tasks;
    using Interfaces;

    public class OrderService : IOrderService
    {
        public async Task<string> CreateAsync(string name, string phoneNumber, string currentLocation, string currentLocationDetails, string endLocation, string endLocationDetails, int countOfPassengers, string additionalRequirements, string taxiDriverName)
        {
            throw new System.NotImplementedException();
        }
    }
}
