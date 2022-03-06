namespace TaxiBook.Areas.Manager.ViewModels
{
    public class Vallidation
    {
        public class CreateViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";

            public const int MaxLocationDetailsLength = 150;

            public const int MaxNameLength = 30;

            public const int MinNameLength = 2;

            public const string StringLengthErrorMessage = "Tрябва да бъде между {2} и {1} символа дълго.";

            public const int MinNumberPlateLength = 6;

            public const int MaxNumberPlateLength = 8;
        }

        public class AddEmployeeViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";
        }
    }
}
