namespace TaxiBook.Services.ViewModels.Favorites
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.CreateFavoriteViewModel;

    public class CreateFavoriteViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string CompanyName { get; set; }
    }
}
