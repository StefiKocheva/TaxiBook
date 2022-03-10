namespace TaxiBook.Data
{
    public class Vallidation
    {
        public class ApplicationUser
        {
            public const int MaxNameLength = 30;
        }

        public class Bookings
        {
            public const int MaxDetailsLength = 150;

            public const int MinPassengersCount = 1;

            public const int MaxPassengersCount = 6;
        }

        public class Feedback
        {
            public const int MaxDescriptionLength = 500;
        }
    }
}
