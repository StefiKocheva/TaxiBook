namespace TaxiBook.Areas.Dispatcher.ViewModels
{
    public class Vallidation
    {
        public class ForthcomingАbsenceViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";
        }

        public class CreateOrderViewModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";

            public const int MaxLocationDetailsLength = 150;

            public const int MaxAdditionalRequirementsLength = 50;

            public const int MinCountOfPassengers = 1;

            public const int MaxCountOfPassengers = 6;
        }
    }
}
