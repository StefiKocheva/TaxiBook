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

            public const int MaxDescriptionLength = 500;

            public const int MinDescriptionLength = 10;

            public const string DescriptionLengthErrorMessage = "Описанието трябва да бъде между {2} и {1} символа дълго.";
        }

        public class CreateFavoriteViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";
        }

        public class EditFavoriteViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";
        }

        public class GiveFeedbackViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";

            public const int MaxDescriptionLength = 150;
        }

        public class CreateOrderViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";

            public const int MaxDetailsLength = 300;

            public const string CountOfPassengersRangeErrorMessage = "Пътниците трябва да бъдат между {1} и {2} броя.";

            public const int MinCountOfPassengers = 1;

            public const int MaxCountOfPassengers = 6;
        }
    }
}
