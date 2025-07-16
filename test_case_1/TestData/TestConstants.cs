namespace test_case_1.TestData
{
    public static class TestConstants
    {
        public static class Urls
        {
            public const string BaseUrl = "https://automationexercise.com/";
        }

        public static class Authentication
        {
            public static string UserName => $"Charleee{DateTime.Now.Ticks}";
            public static string UserEmail => $"charles{DateTime.Now.Ticks}@mail.com";
            public const string Password = "Charles@123";
        }

        public static class DateOfBirth
        {
            public const string Day = "1";
            public const string Month = "1";
            public const string Year = "2000";
        }


        public static class PersonalInfo
        {
            public const string FirstName = "Charles";
            public const string LastName = "Smith";
            public const string Company = "CPM Ltd.";
            public const string PhoneNumber = "1234567890";
        }

        public static class Address
        {
            public const string Address1 = "123 Main St";
            public const string Address2 = "Apt 4B";
            public const string Country = "Canada";
            public const string State = "Ontario";
            public const string City = "Toronto";
            public const string ZipCode = "M4B 1B3";
        }
    }
}