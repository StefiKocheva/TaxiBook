namespace TaxiBook.Areas.Dispatcher.Services
{
    using System;
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
            string name, 
            string phoneNumber, 
            string startLocation, 
            string startLocationDetails, 
            string endLocation, 
            string endLocationDetails, 
            int? countOfPassengers, 
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

            var dispatcher = this.currentUserService.GetUser();
            var dispatcherId = this.currentUserService.GetId();

            var taxiDriver = this.GetTaxiDriver(taxiDriverEmail);

            var order = new Order
            {
                CurrentLocationDetails = startLocationDetails,
                EndLocationDetails = endLocationDetails,
                CountOfPassengers = countOfPassengers,
                AdditionalRequirements = additionalRequirements,
                OrderState = OrderState.Unaccepted,
                CurrentLocationId = location.Id,
                EndLocationId = location.Id,
                User = user,
                CreatedOn = DateTime.Now,
                CreatedBy = dispatcher,
                CreatedById = dispatcherId,
                ProcessedBy = dispatcher,
                ProcessedById = dispatcherId,
                ChosenTaxiDriver = taxiDriver,
                ChosenTaxiDriverId = taxiDriver.Id,
                CompanyId = dispatcher.CompanyId,
                Company = dispatcher.Company,
            };

            await this.db.Orders.AddAsync(order);

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
                    FirstName = o.User.FirstName,
                    LastName = o.User.LastName,
                    PhoneNumber = o.User.PhoneNumber,
                    StartLocation = o.CurrentLocation.StartLocationCoordinates,
                    StartLocationDetails = o.CurrentLocationDetails,
                    EndLocation = o.EndLocation.EndLocationCoordinates,
                    EndLocationDetails = o.EndLocationDetails,
                    CountOfPassengers = o.CountOfPassengers,
                    AdditionalRequirements = o.AdditionalRequirements,
                    CreatedOn = o.CreatedOn,
                    CompletedOn = o.CompletedOn,
                })
                .FirstOrDefaultAsync();

        public IEnumerable<OrderDetailsViewModel> GetAllProcessedOrders()
            => this.db
                .Orders
                .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId)
                .Where(o => o.ProcessedBy == this.currentUserService.GetUser() && o.ProcessedById == this.currentUserService.GetId())
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new OrderDetailsViewModel()
                {
                    Id = o.Id,
                    FirstName = o.User.FirstName,
                    LastName = o.User.LastName,
                    PhoneNumber = o.User.PhoneNumber,
                    StartLocation = o.CurrentLocation.StartLocationCoordinates,
                    StartLocationDetails = o.CurrentLocationDetails,
                    EndLocation = o.EndLocation.EndLocationCoordinates,
                    EndLocationDetails = o.EndLocationDetails,
                    CountOfPassengers = o.CountOfPassengers,
                    AdditionalRequirements = o.AdditionalRequirements,
                    CreatedOn = o.CreatedOn,
                    CompletedOn = o.CompletedOn,
                })
                .ToHashSet();

        public IEnumerable<OrderDetailsViewModel> GetAllRefusedOrders()
            => this.db
                .Orders
                .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId)
                .Where(o => o.UnacceptedBy == this.currentUserService.GetUser() && o.UnacceptedById == this.currentUserService.GetId())
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new OrderDetailsViewModel()
                {
                    Id = o.Id,
                    CreatedOn = o.CreatedOn,
                    CompletedOn = o.CompletedOn,
                })
                .ToHashSet();

        public IEnumerable<OrderDetailsViewModel> GetAllUnprocessedOrders()
            => this.db
                .Orders
                .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId)
                .Where(o => o.OrderState == OrderState.Unprocessed)
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new OrderDetailsViewModel()
                {
                    Id = o.Id,
                    FirstName = o.User.FirstName,
                    LastName = o.User.LastName,
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

        public async Task ProcessAsync(string id)
        {
            var order = this.db
                .Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            order.OrderState = OrderState.Unaccepted;
            order.ProcessedBy = this.currentUserService.GetUser();
            order.ProcessedById = this.currentUserService.GetId();

            await this.db.SaveChangesAsync();
        }

        public async Task UnacceptAsync(string id)
        {
            var order = this.db
                .Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            order.OrderState = OrderState.Unaccepted;
            order.UnacceptedBy = this.currentUserService.GetUser();
            order.UnacceptedById = this.currentUserService.GetId();
            order.CompletedOn = DateTime.Now;

            await this.db.SaveChangesAsync();
        }

        public IEnumerable<DriverDetailsViewModel> GetAvailableDriversDetails()
            => this.db
                .Users
                .Where(u => u.CompanyId == this.currentUserService.GetUser().CompanyId && u.EmployeeRole == EmployeeRole.TaxiDriver)
                .Where(u => u.Taxies.FirstOrDefault().IsBusy == false)
                .Select(u => new DriverDetailsViewModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                })
                .ToHashSet();

        private ApplicationUser GetTaxiDriver(string email)
            => this.db
                .Users
                .Where(u => u.CompanyId == this.currentUserService.GetUser().CompanyId && u.EmployeeRole == EmployeeRole.TaxiDriver)
                .Where(u => u.Email == email)
                .FirstOrDefault();
    }
}
