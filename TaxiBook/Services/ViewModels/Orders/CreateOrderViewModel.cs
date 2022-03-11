namespace TaxiBook.Services.ViewModels.Orders
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TaxiBook.Services.ViewModels.Companies;
    using static Vallidation.CreateOrderViewModel;

    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string CurrentLocation { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string EndLocation { get; set; }

        [MaxLength(MaxDetailsLength)]
        public string CurrentLocationDetails { get; set; }

        [MaxLength(MaxDetailsLength)]
        public string EndLocationDetails { get; set; }

        [Range(
            MinCountOfPassengers,
            MaxCountOfPassengers,
            ErrorMessage = CountOfPassengersRangeErrorMessage)]
        public int CountOfPassengers { get; set; }

        [MaxLength(MaxDetailsLength)]
        public string AdditionalRequirements { get; set; }
    }
}
