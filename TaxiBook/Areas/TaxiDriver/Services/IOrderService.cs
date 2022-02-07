﻿namespace TaxiBook.Areas.TaxiDriver.Services
{
    using System.Threading.Tasks;

    public interface IOrderService
    {
        Task<string> CreateAsync(string name, string phoneNumber, string currentLocation, string currentLocationDetails, string endLocation, string endLocationDetails, int countOfPassengers, string additionalRequirements, string taxiDriverName);
    }
}
