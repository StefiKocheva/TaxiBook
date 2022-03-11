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

            public const int MaxDetailsLength = 300;

            public const string CountOfPassengersRangeErrorMessage = "Пътниците трябва да бъдат между {1} и {2} броя.";

            public const int MinCountOfPassengers = 1;

            public const int MaxCountOfPassengers = 6;
        }
    }
}
