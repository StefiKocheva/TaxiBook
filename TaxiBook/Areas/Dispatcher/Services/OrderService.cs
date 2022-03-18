namespace TaxiBook.Areas.Dispatcher.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Interfaces;
    using ViewModels.Orders;
    using Data.Models.Enums;

    public class OrderService : IOrderService
    {
        private readonly TaxiBookDbContext db;

        public OrderService(TaxiBookDbContext db) 
            => this.db = db;

        public async Task<string> CreateAsync(
            string name, 
            string phoneNumber, 
            string startLocation, 
            string startLocationDetails, 
            string endLocation, 
            string endLocationDetails, 
            int countOfPassengers, 
            string additionalRequirements, 
            string taxiDriverEmail)
        {
            var user = new ApplicationUser
            {
                FirstName = name,
                PhoneNumber = phoneNumber,
            };

            await this.db.Users.AddAsync(user);

            await this.db.SaveChangesAsync();

            var location = new Address()
            {
                StartLocationCoordinates = startLocation,
                EndLocationCoordinates = endLocation,
            };

            await this.db.Addresses.AddAsync(location);

            await this.db.SaveChangesAsync();

            var order = new Order
            {
                CurrentLocationDetails = startLocationDetails,
                EndLocationDetails = endLocationDetails,
                CountOfPassengers = countOfPassengers,
                AdditionalRequirements = additionalRequirements,
                OrderState = OrderState.Processed,
                CurrentLocationId = location.Id,
                EndLocationId = location.Id,
            };

            await this.db.Orders.AddAsync(order);

            await this.db.SaveChangesAsync();

            var taxiDriver = new ApplicationUser()
            {
                Email = taxiDriverEmail,
            };

            await this.db.Users.AddAsync(taxiDriver);

            await this.db.SaveChangesAsync();

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
                    StartLocation = o.CurrentLocation.ToString(),
                    EndLocation = o.EndLocation.ToString(),
                    StartLocationDetails = o.CurrentLocationDetails,
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

        private async Task<Order?> ByIdAndByUserId(
            string id, 
            string userId)
            => await this.db
                .Orders
                .Where(o => o.Id == id && o.UserId == userId)
                .FirstOrDefaultAsync();
    }
}
