﻿namespace TaxiBook.Services.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.CreateOrderViewModel;

    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string CurrentLocation { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string EndLocation { get; set; }

        [MaxLength(MaxLocationDetailsLength)]
        public string CurrentLocationDetails { get; set; }

        [MaxLength(MaxLocationDetailsLength)]
        public string EndLocationDetails { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinCountOfPassengers, MaxCountOfPassengers)]
        public int CountOfPassengers { get; set; }

        [MaxLength(MaxAdditionalRequirementsLength)]
        public string AdditionalRequirements { get; set; }
    }
}