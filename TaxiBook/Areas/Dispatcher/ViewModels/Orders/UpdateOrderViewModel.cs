namespace TaxiBook.Areas.Dispatcher.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.CreateOrderViewModel;

    public class UpdateOrderViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string ClientName { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string StartLocation { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string EndLocation { get; set; }

        [MaxLength(MaxLocationDetailsLength)]
        public string StartLocationDetails { get; set; }

        [MaxLength(MaxLocationDetailsLength)]
        public string EndLocationDetails { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinCountOfPassengers, MaxCountOfPassengers)]
        public int CountOfPassengers { get; set; }

        [MaxLength(MaxAdditionalRequirementsLength)]
        public string AdditionalRequirements { get; set; }
    }
}
