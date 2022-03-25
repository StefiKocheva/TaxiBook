namespace TaxiBook.Areas.TaxiDriver.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Inerfaces;
    using Microsoft.EntityFrameworkCore;
    using TaxiBook.Infrastructure.Services;
    using ViewModels.Orders;

    public class OrderService : IOrderService
    {
        private readonly TaxiBookDbContext db;
        private readonly ICurrentUserService currentUserService;

        public OrderService(TaxiBookDbContext db, ICurrentUserService currentUserService)
        {
            this.db = db;
            this.currentUserService = currentUserService;
        }

        public async Task<string> CreateAsync(
            string endLocation, 
            int countOfPassengers)
        {
            var location = new Address()
            {
                EndLocationCoordinates = endLocation,
            };

            await this.db.Addresses.AddAsync(location);
            await this.db.SaveChangesAsync();

            var order = new Order
            {
                CountOfPassengers = countOfPassengers,
                EndLocationId = location.Id,
            };

            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();

            return order.Id;
        }

        public async Task<OrderDetailsViewModel> DetailsAsync(string id)
            => await this.db
                .Orders
                .Where(o => o.Id == id)
                .Select(o => new OrderDetailsViewModel()
                {
                    Id = o.Id,
                    CreatorId = o.UserId,
                    ClientName = o.User.FirstName + " " + o.User.LastName,
                    PhoneNumber = o.User.PhoneNumber,
                    CurrentLocation = o.CurrentLocation.ToString(),
                    EndLocation = o.EndLocation.ToString(),
                    CurrentLocationDetails = o.CurrentLocationDetails,
                    EndLocationDetails = o.EndLocationDetails,
                    CountOfPassengers = o.CountOfPassengers,
                    AdditionalRequirements = o.AdditionalRequirements,

                })
                .FirstOrDefaultAsync();

        public async void UpdateAsync(
            string id,
            string name,
            string phoneNumber,
            string currentLocation,
            string currentLocationDetails,
            string endLocation,
            string endLocationDetails,
            int countOfPassengers,
            string additionalRequirements,
            string userId)
        {
            var order = await this.ByIdAndByUserId(id, userId);

            //if (order == null)
            //{
            //    return "";
            //}

            var orderClientName = order.User.FirstName + " " + order.User.LastName;
            orderClientName = name;
            order.User.PhoneNumber = phoneNumber;
            var orderCurrentLocation = order.CurrentLocation.ToString();
            orderCurrentLocation = currentLocation;
            var orderEndLocation = order.EndLocation.ToString();
            orderEndLocation = endLocation;
            order.CurrentLocationDetails = currentLocationDetails;
            order.EndLocationDetails = endLocationDetails;
            order.CountOfPassengers = countOfPassengers;
            order.AdditionalRequirements = additionalRequirements;

            await this.db.SaveChangesAsync();
        }

        private async Task<Order?> ByIdAndByUserId(string id, string userId)
            => await this.db
                .Orders
                .Where(o => o.Id == id && o.UserId == userId)
                .FirstOrDefaultAsync();
    }
}
