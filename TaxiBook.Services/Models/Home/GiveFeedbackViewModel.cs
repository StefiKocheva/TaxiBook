namespace TaxiBook.Services.Models.Home
{
    using System.ComponentModel.DataAnnotations;

    public class GiveFeedbackViewModel
    {
        // Enum?
        [Required]
        public string Company { get; set; }

        [Required]
        public bool IsLiked { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
    }
}
