namespace TaxiBook.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Infrastructure.Services;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using ViewModels.Orders;

    public class OrderService : IOrderService
    {
        private readonly TaxiBookDbContext db;
        private readonly ICurrentUserService currentUserService;

        public OrderService(
            TaxiBookDbContext db, 
            ICurrentUserService currentUserService)
        {
            this.db = db;
            this.currentUserService = currentUserService;
        }

        public async Task<string> CreateAsync(
            string currentLocation, 
            string currentLocationDetails, 
            string endLocation, 
            string endLocationDetails, 
            int countOfPassengers, 
            string additionalRequirements)
        {
            var location = new Address()
            {
                StartLocationCoordinates = currentLocation,
                EndLocationCoordinates = endLocation,
            };

            await this.db.Addresses.AddAsync(location);
            await this.db.SaveChangesAsync();

            var order = new Order
            {
                CurrentLocationDetails = currentLocationDetails,
                EndLocationDetails = endLocationDetails,
                CountOfPassengers = countOfPassengers,
                AdditionalRequirements = additionalRequirements,
                OrderState = OrderState.Unprocessed,
                User = this.currentUserService.GetUser(),
                CurrentLocationId = location.Id,
                EndLocationId = location.Id,
            };

            await this.db.Orders.AddAsync(order);

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
                    CurrentLocation = o.CurrentLocation.StartLocationCoordinates,
                    EndLocation = o.EndLocation.EndLocationCoordinates,
                    CurrentLocationDetails = o.CurrentLocationDetails,
                    EndLocationDetails  = o.EndLocationDetails,
                    CountOfPassengers = o.CountOfPassengers,
                    AdditionalRequirements = o.AdditionalRequirements,
                })
                .FirstOrDefaultAsync();

        public IEnumerable<OrderDetailsViewModel> Overview()
            => this.db
            .Orders
            .Where(o => o.UserId == this.currentUserService.GetId())
            .OrderByDescending(o => o.CreatedOn)
            .Where(o => o.OrderState == OrderState.Unprocessed)
            .Select(o => new OrderDetailsViewModel()
            {
                CurrentLocation = o.CurrentLocation.StartLocationCoordinates,
                CurrentLocationDetails = o.CurrentLocationDetails,
                EndLocation = o.EndLocation.EndLocationCoordinates,
                EndLocationDetails = o.EndLocationDetails,
                CountOfPassengers = o.CountOfPassengers,
                AdditionalRequirements = o.AdditionalRequirements,
            })
            .Take(1)
            .ToHashSet();

        public IEnumerable<OrderDetailsViewModel> OverviewPast()
            => this.db
            .Orders
            .Where(o => o.UserId == this.currentUserService.GetId())
            .OrderByDescending(o => o.CreatedOn)
            .Where(o => o.OrderState == OrderState.Past)
            .Select(o => new OrderDetailsViewModel()
            {
                CurrentLocation = o.CurrentLocation.StartLocationCoordinates,
                CurrentLocationDetails = o.CurrentLocationDetails,
                EndLocation = o.EndLocation.EndLocationCoordinates,
                EndLocationDetails = o.EndLocationDetails,
                CountOfPassengers = o.CountOfPassengers,
                AdditionalRequirements = o.AdditionalRequirements,
            })
            .ToHashSet();

        private async Task<Order> ByIdAndByUserId(
            string id, 
            string userId)
            => await this.db
                .Orders
                .Where(o => o.Id == id && o.UserId == userId)
                .FirstOrDefaultAsync();
    }   
}
