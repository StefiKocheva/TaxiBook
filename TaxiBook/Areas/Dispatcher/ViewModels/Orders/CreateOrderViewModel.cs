﻿namespace TaxiBook.Areas.Dispatcher.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string CurrentLocation { get; set; }

        [Required]
        public string EndLocation { get; set; }

        [MaxLength(100)]
        public string CurrentLocationDetails { get; set; }

        [MaxLength(100)]
        public string EndLocationDetails { get; set; }

        [Required]
        [Range(1, 6)]
        public int CountOfPassengers { get; set; }

        [MaxLength(50)]
        public string AdditionalRequirements { get; set; }

        [Required]
        public string TaxiDriver { get; set; }
    }
}
