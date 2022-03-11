namespace TaxiBook.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using TaxiBook.Data.Models.Enums;
    using ViewModels.Orders;

    public class OrderService : IOrderService
    {
        private readonly TaxiBookDbContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrderService(
            TaxiBookDbContext db, 
            IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> CreateAsync(
            string currentLocation, 
            string currentLocationDetails, 
            string endLocation, 
            string endLocationDetails, 
            int countOfPassengers, 
            string additionalRequirements)
        {

            var userName = this.httpContextAccessor.HttpContext.User.Identity.Name;
            var user = this.db.Users.FirstOrDefault(x => x.UserName == userName);

            var order = new Order
            {
                CurrentLocationDetails = currentLocationDetails,
                EndLocationDetails = endLocationDetails,
                CountOfPassengers = countOfPassengers,
                AdditionalRequirements = additionalRequirements,
                OrderState = OrderState.Unprocessed,
                User = user,
                UserId = user.Id,
            };

            await this.db.Orders.AddAsync(order);

            await this.db.SaveChangesAsync();
            var location = new Address()
            {
                StartLocationCoordinates = currentLocation,
                EndLocationCoordinates = endLocation,
                User = user,
                UserId = user.Id,
            };

            await this.db.Addresses.AddAsync(location);

            await this.db.SaveChangesAsync();

            return order.Id;
        }

        public async void DeleteAsync(
            string id,
            string userId)
        {
            var order = await this.ByIdAndByUserId(id, userId);

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

        private async Task<Order> ByIdAndByUserId(
            string id, 
            string userId)
            => await this.db
                .Orders
                .Where(o => o.Id == id && o.UserId == userId)
                .FirstOrDefaultAsync();
    }   
}
