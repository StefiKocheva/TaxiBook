namespace TaxiBook.Areas.Dispatcher.Services
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

        public OrderService(TaxiBookDbContext db, ICurrentUserService currentUserService)
        {
            this.db = db;
            this.currentUserService = currentUserService;
        }

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
                User = user,
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
                    CreatedOn = o.CreatedOn,  
                })
                .FirstOrDefaultAsync();

        public IEnumerable<OrderDetailsViewModel> GetAllProcessedOrders()
            => this.db
                .Orders
                .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId && o.OrderState == OrderState.Processed)
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new OrderDetailsViewModel()
                {
                    Id = o.Id,
                    ClientName = o.User.FirstName + o.User.LastName,
                    //CreatorId = can be in role: Client, Dispatcher or TaxiDriver
                    PhoneNumber = o.User.PhoneNumber,
                    StartLocation = o.CurrentLocation.StartLocationCoordinates,
                    StartLocationDetails = o.CurrentLocationDetails,
                    EndLocation = o.EndLocation.EndLocationCoordinates,
                    EndLocationDetails = o.EndLocationDetails,
                    CountOfPassengers = o.CountOfPassengers,
                    AdditionalRequirements = o.AdditionalRequirements,
                    CreatedOn = o.CreatedOn,
                })
                .ToHashSet();

        public IEnumerable<OrderDetailsViewModel> GetAllRefusedOrders()
            => this.db
                .Orders
                .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId)
                .Where(o => o.OrderState == OrderState.Unaccepted || o.OrderState == OrderState.Refused)
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new OrderDetailsViewModel()
                {
                    Id = o.Id,
                    //CreatorId = can be in role: Client, Dispatcher or TaxiDriver
                    CreatedOn = o.CreatedOn,
                    CompletedOn = o.CompletedOn,
                })
                .ToHashSet();

        public IEnumerable<OrderDetailsViewModel> GetAllUnprocessedOrders()
            => this.db
                .Orders
                .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId && o.OrderState == OrderState.Unprocessed)
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new OrderDetailsViewModel()
                {
                    Id = o.Id,
                    ClientName = o.User.FirstName + o.User.LastName,
                    //CreatorId = can be in role: Client, Dispatcher or TaxiDriver
                    PhoneNumber = o.User.PhoneNumber,
                    StartLocation = o.CurrentLocation.StartLocationCoordinates,
                    StartLocationDetails = o.CurrentLocationDetails,
                    EndLocation = o.EndLocation.EndLocationCoordinates,
                    EndLocationDetails = o.EndLocationDetails,
                    CountOfPassengers = o.CountOfPassengers,
                    AdditionalRequirements = o.AdditionalRequirements,
                    CreatedOn = o.CreatedOn,
                })
                .ToHashSet();

        public async void ProcessAsync(string id)
        {
            var order = await this.db
                .Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            order.OrderState = OrderState.Processed;

            await this.db.SaveChangesAsync();
        }

        public async void RefuseAsync(string id)
        {
            var order = await this.db
                .Orders
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            order.OrderState = OrderState.Unaccepted;

            await this.db.SaveChangesAsync();
        }

        //public IEnumerable<DriverDetailsViewModel> GetAvailableDriversDetails()
        //    => this.db
        //    .Taxies
        //    .Where(t => !t.IsBusy)
        //    .Select(t => t.Users
        //    .Where(u => u.CompanyId == this.currentUserService.GetUser().CompanyId)
        //    .Select(u => new DriverDetailsViewModel()
        //    {
        //        Id = u.Id,
        //        Email = u.Email,
        //    }))
        //    .ToHashSet();
    }
}
