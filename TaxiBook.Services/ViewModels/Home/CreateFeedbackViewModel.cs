namespace TaxiBook.Services.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.GiveFeedbackViewModel;

    public class CreateFeedbackViewModel
    {
        // Enum?
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Company { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public bool IsLiked { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Opinion { get; set; }
    }
}
