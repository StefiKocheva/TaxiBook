namespace TaxiBook.Areas.TaxiDriver.Services
{
    using System;
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

        public OrderService(
            TaxiBookDbContext db, 
            ICurrentUserService currentUserService)
        {
            this.db = db;
            this.currentUserService = currentUserService;
        }

        public async Task AcceptAsync(string id)
        {
            var order = this.db
                .Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            order.OrderState = OrderState.Accepted;
            order.AcceptedBy = this.currentUserService.GetUser();
            order.AcceptedById = this.currentUserService.GetId();

            await this.db.SaveChangesAsync();
        }

        public async Task<string> CreateAsync(
            string endLocation, 
            int? countOfPassengers)
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
                CreatedBy = this.currentUserService.GetUser(),
                CreatedById = this.currentUserService.GetId(),
                AcceptedBy = this.currentUserService.GetUser(),
                AcceptedById = this.currentUserService.GetId(),
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

        public IEnumerable<OrderDetailsViewModel> GetAllAcceptedOrders()
            => this.db
                .Orders
                .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId)
                .Where(o => o.AcceptedBy == this.currentUserService.GetUser() && o.AcceptedById == this.currentUserService.GetId())
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

        public IEnumerable<OrderDetailsViewModel> GetAllUnacceptedOrders()
            => this.db
                .Orders
                .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId)
                .Where(o => o.OrderState == OrderState.Unaccepted)
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

        public async Task<OrderDetailsViewModel> OverviewAsync()
            => await this.db
            .Orders
            .Where(o => o.CompanyId == this.currentUserService.GetUser().CompanyId)
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
            .FirstOrDefaultAsync();
    }
}
