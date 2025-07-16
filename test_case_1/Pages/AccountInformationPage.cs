using Microsoft.Playwright;

namespace test_case_1.Pages
{
    public class AccountInformationPage : BasePage
    {
        public AccountInformationPage(IPage page) : base(page)
        {
        }

        private ILocator EnterAccountInformationLabel => _page.Locator("text=Enter Account Information");
        private ILocator TitleMrRadioButton => _page.Locator("input[id='id_gender1']");
        private ILocator PasswordField => _page.Locator("input[data-qa='password']");
        private ILocator DayDropdown => _page.Locator("select[data-qa='days']");
        private ILocator MonthDropdown => _page.Locator("select[data-qa='months']");
        private ILocator YearDropdown => _page.Locator("select[data-qa='years']");
        private ILocator NewsletterCheckbox => _page.Locator("input[id='newsletter']");
        private ILocator SpecialOffersCheckbox => _page.Locator("input[id='optin']");
        private ILocator FirstNameField => _page.Locator("input[data-qa='first_name']");
        private ILocator LastNameField => _page.Locator("input[data-qa='last_name']");
        private ILocator CompanyField => _page.Locator("input[data-qa='company']");
        private ILocator Address1Field => _page.Locator("input[data-qa='address']");
        private ILocator Address2Field => _page.Locator("input[data-qa='address2']");
        private ILocator CountryDropdown => _page.Locator("select[data-qa='country']");
        private ILocator StateField => _page.Locator("input[data-qa='state']");
        private ILocator CityField => _page.Locator("input[data-qa='city']");
        private ILocator ZipcodeField => _page.Locator("input[data-qa='zipcode']");
        private ILocator MobileNumberField => _page.Locator("input[data-qa='mobile_number']");
        private ILocator CreateAccountButton => _page.Locator("button[data-qa='create-account']");

        public Task<bool> IsEnterAccountInformationVisibleAsync()
        {
            return IsElementVisibleAsync(EnterAccountInformationLabel);
        }

        public Task ClickTitleMrRadioButtonAsync()
        {
            return CheckElementAsync(TitleMrRadioButton);
        }

        public Task FillPasswordAsync(string password)
        {
            return FillInputAsync(PasswordField, password);
        }

        public async Task SelectDateOfBirthAsync(string day, string month, string year)
        {
            await SelectOptionAsync(DayDropdown, day);
            await SelectOptionAsync(MonthDropdown, month);
            await SelectOptionAsync(YearDropdown, year);
        }

        public Task ClickNewsletterCheckboxAsync()
        {
            return CheckElementAsync(NewsletterCheckbox);
        }

        public Task ClickSpecialOffersCheckboxAsync()
        {
            return CheckElementAsync(SpecialOffersCheckbox);
        }

        public async Task FillPersonalNameAsync(string firstname, string lastname)
        {
            await FillInputAsync(FirstNameField, firstname);
            await FillInputAsync(LastNameField, lastname);
        }

        public Task FillCompanyAsync(string company)
        {
            return FillInputAsync(CompanyField, company);
        }

        public async Task FillAddressAsync(string address1, string address2)
        {
            await FillInputAsync(Address1Field, address1);
            await FillInputAsync(Address2Field, address2);
        }

        public Task SelectCountryAsync(string country)
        {
            return SelectOptionAsync(CountryDropdown, country);
        }

        public async Task FillLocationDetailsAsync(string state, string city, string zipcode)
        {
            await FillInputAsync(StateField, state);
            await FillInputAsync(CityField, city);
            await FillInputAsync(ZipcodeField, zipcode);
        }

        public Task FillPhoneNumberAsync(string phoneNumber)
        {
            return FillInputAsync(MobileNumberField, phoneNumber);
        }

        public Task ClickCreateAccountButtonAsync()
        {
            return ClickElementAsync(CreateAccountButton);
        }
    }
}