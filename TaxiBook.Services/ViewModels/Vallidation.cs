namespace TaxiBook.Services.ViewModels
{
    public class Vallidation
    {
        public class CreateCompanyViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";

            public const string CompanyNameLengthErrorMessage = "Името трябва да бъде между {2} и {1} символа дълго.";

            public const int MaxNameLength = 30;

            public const int MinNameLength = 2;
        }

        public class CreateFavoriteViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";
        }

        public class GiveFeedbackViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително";

            public const int MaxDescriptionLength = 150;
        }

        public class CreateOrderViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително";

            public const int MaxLocationDetailsLength = 150;

            public const int MaxAdditionalRequirementsLength = 50;

            public const int MinCountOfPassengers = 1;

            public const int MaxCountOfPassengers = 6;
        }
    }
}
