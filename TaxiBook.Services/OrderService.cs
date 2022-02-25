namespace TaxiBook.Services
{
    using System.Threading.Tasks;
    using Interfaces;
    using Data;
    using Data.Models;

    public class OrderService : IOrderService
    {
        private readonly TaxiBookDbContext db;

        public OrderService(TaxiBookDbContext db)
        {
            this.db = db;
        }

        public async Task<string> CreateAsync(string currentLocation, string currentLocationDetails, string endLocation, string endLocationDetails, int countOfPassengers, string additionalRequirements)
        {
            var order = new Booking
            {
                // CurrentLocation = currentLocation,
                // EndLocation = endLocation,
                CurrentLocationDetails = currentLocationDetails,
                EndLocationDetails = endLocationDetails,
                CountOfPassengers = countOfPassengers,
                AdditionalRequirements = additionalRequirements,
            };

            await db.Bookings.AddAsync(order);

            await db.SaveChangesAsync();

            return order.Id;
        }

        public void DeleteAsync(string id, string clientId)
        {
            throw new System.NotImplementedException();
        }
    }
}
