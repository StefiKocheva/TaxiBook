namespace TaxiBook.Areas.Dispatcher.Services
{
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Services.Interfaces;

    public class OrderService : IOrderService
    {
        private readonly TaxiBookDbContext db;

        public OrderService(TaxiBookDbContext db)
        {
            this.db = db;
        }

        public async Task<string> CreateAsync(string name, string phoneNumber, string currentLocation, string currentLocationDetails, string endLocation, string endLocationDetails, int countOfPassengers, string additionalRequirements, string taxiDriverName)
        {
            var order = new Booking
            {
                // ClientName = name,
                // PhoneNumber = phoneNumber,
                // CurrentLocation = currentLocation,
                // EndLocation = endLocation,
                CurrentLocationDetails = currentLocationDetails,
                EndLocationDetails = endLocationDetails,
                CountOfPassengers = countOfPassengers,
                AdditionalRequirements = additionalRequirements, 
                // Taxi.Driver.FullName (FirstName + LastName) = taxiDriverName,
            };

            await db.Bookings.AddAsync(order);

            await db.SaveChangesAsync();

            return order.Id;
        }
    }
}
