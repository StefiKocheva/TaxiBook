namespace TaxiBook.Services.ViewModels.Feedbacks
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.GiveFeedbackViewModel;

    public class CreateFeedbackViewModel
    {
        public string Company { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public bool IsLiked { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Opinion { get; set; }
    }
}
