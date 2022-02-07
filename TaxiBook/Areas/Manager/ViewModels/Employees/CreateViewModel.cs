namespace TaxiBook.Areas.Manager.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    public class CreateViewModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(80)]
        public string BrandAndModel { get; set; }

        [Required]
        [Range(6, 8)]
        public string NumberPlate { get; set; }
    }
}
