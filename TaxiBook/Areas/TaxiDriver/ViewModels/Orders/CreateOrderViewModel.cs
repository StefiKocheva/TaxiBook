namespace TaxiBook.Areas.TaxiDriver.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.CreateOrderViewModel;

    public class CreateOrderViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string EndLocation { get; set; }

        public int? CountOfPassengers { get; set; }
    }
}
