namespace TaxiBook.Services.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

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

        //[Required(ErrorMessage = RequiredErrorMessage)]
        //[Range(10, 1000,
        //ErrorMessage = "Value for {0} must be between {1} and {2}.")] 
        public int CountOfPassengers { get; set; }

        [MaxLength(MaxDetailsLength)]
        public string AdditionalRequirements { get; set; }
    }
}
