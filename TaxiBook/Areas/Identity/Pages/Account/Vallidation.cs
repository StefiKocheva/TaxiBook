namespace TaxiBook.Areas.Identity.Pages.Account
{
    public class Vallidation
    {
        public class ForgotPasswordModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";
        }

        public class LoginModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";

            public const string DisplayRememberMeName = "Запомни ме?";
        }

        public class RegisterModel
        {
            public const string RequiredErrorMessage = "Полето е задължително.";

            public const string FirstNameLengthErrorMessage = "Първото име трябва да бъде между {2} и {1} символа дълго.";

            public const string LastNameLengthErrorMessage = "Фамилията трябва да бъде между {2} и {1} символа дълга.";

            public const string PasswordLengthErrorMessage = "{0} трябва да бъде поне {2} и максимално {1} символа дълга.";

            public const int MaxNameLength = 30;

            public const int MinNameLength = 2;

            public const int MaxPasswordLength = 100;

            public const int MinPasswordLength = 6;

            public const string ComparePasswordErrorMessage = "Паролите не съвпадат.";

            public const string DisplayConfirmPasswordName = "Потвърждаване на парола";

            public const string DisplayPasswordName = "Паролата";

            public const string DisplayEmailName = "Email";

            public const string DisplayPhoneNumberName = "Телефонен номер";

            public const string PasswordPropertyName = "Password";
        }
    }
}
