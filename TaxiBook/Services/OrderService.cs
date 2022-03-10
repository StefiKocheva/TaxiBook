namespace TaxiBook.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using ViewModels.Orders;

    public class OrderService : IOrderService
    {
        private readonly TaxiBookDbContext db;

        public OrderService(TaxiBookDbContext db) => this.db = db;

        public async Task<string> CreateAsync(
            string currentLocation, 
            string currentLocationDetails, 
            string endLocation, 
            string endLocationDetails, 
            int countOfPassengers, 
            string additionalRequirements)
        {
            var location = new Address
            {
                Coordinates = currentLocation,
            };

            var order = new Order
            {
                CurrentLocationDetails = currentLocationDetails,
                EndLocationDetails = endLocationDetails,
                CountOfPassengers = countOfPassengers,
                AdditionalRequirements = additionalRequirements,
            };

            await db.Orders.AddAsync(order);

            await db.SaveChangesAsync();

            return order.Id;
        }

        public async void DeleteAsync(
            string id,
            string userId)
        {
            var order = await this.ByIdAndByUserId(id, userId);
            //if (order == null)
            //{
            //    Is it necessary to check if it's null?
            //}

            this.db.Orders.Remove(order);

            await this.db.SaveChangesAsync();
        }

        public async Task<OrderDetailsViewModel> DetailsAsync(string id)
            => await this.db
                .Orders
                .Where(o => o.Id == id)
                .Select(o => new OrderDetailsViewModel()
                {
                    Id = o.Id,
                    ClientId = o.UserId,
                    PhoneNumber = o.User.PhoneNumber,
                    CurrentLocation = o.CurrentLocation.ToString(),
                    EndLocation = o.EndLocation.ToString(),
                    CurrentLocationDetails = o.CurrentLocationDetails,
                    EndLocationDetails  = o.EndLocationDetails,
                    CountOfPassengers = o.CountOfPassengers,
                    AdditionalRequirements = o.AdditionalRequirements,
                })
                .FirstOrDefaultAsync();

        private async Task<Order?> ByIdAndByUserId(
            string id, 
            string userId)
            => await this.db
                .Orders
                .Where(o => o.Id == id && o.UserId == userId)
                .FirstOrDefaultAsync();
    }   
}
