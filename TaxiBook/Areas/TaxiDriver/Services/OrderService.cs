namespace TaxiBook.Areas.TaxiDriver.Services
{
    using System.Threading.Tasks;
    using Data.Models;

    public class OrderService : IOrderService
    {
        public async Task<string> CreateAsync(string name, string phoneNumber, string currentLocation, string currentLocationDetails, string endLocation, string endLocationDetails, int countOfPassengers, string additionalRequirements, string taxiDriverName)
        {
            var order = new Booking
            {
                // ClientName = name,
                // PhoneNumber = phoneNumber,
                // CurrentLocation = currentLocation,
                // CurrentLocationDetails = currentLocationDetails,
                // EndLocation = endLocation,
                // EndLocationDetails = endLocationDetails,
                // CountOfPassengers = countOfPassengers,
                // AdditionalRequirements = additionalRequirements, 
                // TaxiDriverName = taxiDriverName,
            };

            // return this.order.Id;

            return " ";
        }
    }
}
