namespace TaxiBook.Areas.Dispatcher.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.CreateOrderViewModel;

    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string ClientName { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string StartLocation { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string EndLocation { get; set; }

        [MaxLength(MaxDetailsLength)]
        public string StartLocationDetails { get; set; }

        [MaxLength(MaxDetailsLength)]
        public string EndLocationDetails { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]

        //[Range(
        //    MinCountOfPassengers, 
        //    MaxCountOfPassengers, 
        //    ErrorMessage = CountOfPassengersRangeErrorMessage)]
        public int CountOfPassengers { get; set; }

        [MaxLength(MaxDetailsLength)]
        public string AdditionalRequirements { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string TaxiDriver { get; set; }
    }
}
