namespace TaxiBook.Areas.TaxiDriver.Services
{
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Services.Inerfaces;

    public class TaxiDriverOrderService : ITaxiDriverOrderService
    {
        private readonly TaxiBookDbContext db;

        public TaxiDriverOrderService(TaxiBookDbContext db)
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
    }
}
