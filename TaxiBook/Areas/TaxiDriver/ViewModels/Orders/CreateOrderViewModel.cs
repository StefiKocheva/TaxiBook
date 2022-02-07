namespace TaxiBook.Areas.TaxiDriver.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderViewModel
    {
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
    }
}
