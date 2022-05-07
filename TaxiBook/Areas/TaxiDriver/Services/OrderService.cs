namespace TaxiBook.Areas.TaxiDriver.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Inerfaces;
    using Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
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

        public async void AcceptAsync(string id)
        {
            var order = await this.db
                .Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            order.OrderState = OrderState.Accepted;

            await this.db.SaveChangesAsync();
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
                CompanyId = this.currentUserService.GetUser().CompanyId,
                CountOfPassengers = countOfPassengers,
                EndLocationId = location.Id,
                OrderState = OrderState.Accepted,
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
                    CurrentLocation = o.CurrentLocation.StartLocationCoordinates,
                    CurrentLocationDetails = o.CurrentLocationDetails,
                    EndLocation = o.EndLocation.EndLocationCoordinates,
                    EndLocationDetails = o.EndLocationDetails,
                    CountOfPassengers = o.CountOfPassengers,
                    AdditionalRequirements = o.AdditionalRequirements,
                    CreatedOn = o.CreatedOn,
                    CompletedOn = o.CompletedOn,
                })
                .FirstOrDefaultAsync();

        public IEnumerable<OrderDetailsViewModel> GetAllAcceptedOrders()
            => this.db
            .Orders
            .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId)
            .Where(o => o.OrderState == OrderState.Accepted)
            .OrderByDescending(o => o.CreatedOn)
            .Select(o => new OrderDetailsViewModel()
            {
                Id = o.Id,
                //CreatorId = can be in role: Client, Dispatcher or TaxiDriver
                ClientName = o.User.FirstName + " " + o.User.LastName,
                PhoneNumber = o.User.PhoneNumber,
                CurrentLocation = o.CurrentLocation.StartLocationCoordinates,
                CurrentLocationDetails = o.CurrentLocationDetails,
                EndLocation = o.EndLocation.EndLocationCoordinates,
                EndLocationDetails = o.EndLocationDetails,
                CountOfPassengers = o.CountOfPassengers,
                AdditionalRequirements = o.AdditionalRequirements,
                CreatedOn = o.CreatedOn,
                CompletedOn = o.CompletedOn,
            })
            .ToHashSet();

        public IEnumerable<OrderDetailsViewModel> GetAllRefusedOrders()
            =>  this.db
            .Orders
            .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId)
            .Where(o => o.OrderState == OrderState.Refused)
            .OrderByDescending(o => o.CreatedOn)
            .Select(o => new OrderDetailsViewModel()
            {
                Id = o.Id,
                //CreatorId = can be in role: Client, Dispatcher or TaxiDriver
                CreatedOn = o.CreatedOn,
                CompletedOn = o.CompletedOn,
            })
            .ToHashSet();

        public IEnumerable<OrderDetailsViewModel> GetAllUnacceptedOrders()
            => this.db
            .Orders
            .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId)
            .Where(o => o.OrderState == OrderState.Unaccepted)
            .Select(o => new OrderDetailsViewModel()
            {
                Id = o.Id,
                ClientName = o.User.FirstName + " " + o.User.LastName,
                PhoneNumber = o.User.PhoneNumber,
                CurrentLocation = o.CurrentLocation.StartLocationCoordinates,
                CurrentLocationDetails = o.CurrentLocationDetails,
                EndLocation = o.EndLocation.EndLocationCoordinates,
                EndLocationDetails = o.EndLocationDetails,
                CountOfPassengers = o.CountOfPassengers,
                AdditionalRequirements = o.AdditionalRequirements,
                CreatedOn = o.CreatedOn,
            })
            .ToHashSet();

        public async Task<OrderDetailsViewModel> OverviewAsync()
            => await this.db
            .Orders
            .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId)
            .OrderByDescending(o => o.CreatedOn)
            .Select(o => new OrderDetailsViewModel()
            {
                Id = o.Id,
                ClientName = o.User.FirstName + " " + o.User.LastName,
                PhoneNumber = o.User.PhoneNumber,
                CurrentLocation = o.CurrentLocation.StartLocationCoordinates,
                CurrentLocationDetails = o.CurrentLocationDetails,
                EndLocation = o.EndLocation.EndLocationCoordinates,
                EndLocationDetails = o.EndLocationDetails,
                CountOfPassengers = o.CountOfPassengers,
                AdditionalRequirements = o.AdditionalRequirements,
                CreatedOn = o.CreatedOn,
            })
            .FirstOrDefaultAsync();
    }
}
