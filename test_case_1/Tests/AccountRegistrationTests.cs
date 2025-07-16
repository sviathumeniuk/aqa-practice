using Microsoft.Playwright.NUnit;
using test_case_1.Pages;
using test_case_1.TestData;

namespace test_case_1;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class AccountRegistrationTests : PageTest
{
    private HomePage _homePage;
    private AuthorizePage _authorizePage;
    private AccountInformationPage _accountInformationPage;
    private AccountCreatedPage _accountCreatedPage;

    [SetUp]
    public async Task Setup()
    {
        await Context.ClearCookiesAsync();
        await Context.ClearPermissionsAsync();

        _homePage = new HomePage(Page);
        _authorizePage = new AuthorizePage(Page);
        _accountInformationPage = new AccountInformationPage(Page);
        _accountCreatedPage = new AccountCreatedPage(Page);
    }

    [Test]
    public async Task AccountRegistration()
    {
        await NavigateToHomePage();
        await SignUpNewUser();
        await FillAccountInformation();
        await VerifyAccountCreatedAndLogin();
        await DeleteAccount();
    }

    #region Private Test Steps

    private async Task NavigateToHomePage()
    {
        await this._homePage.NavigateToHomePageAsync(TestConstants.Urls.BaseUrl);

        var isHomePageVisible = await this._homePage.IsHomePageContentVisibleAsync();
        Assert.That(isHomePageVisible, Is.True, "Home page should be visible.");
    }

    private async Task SignUpNewUser()
    {
        await this._homePage.ClickSignupLoginButtonAsync();

        var isNewUserSignupVisible = await this._authorizePage.IsNewUserSignupVisibleAsync();
        Assert.That(isNewUserSignupVisible, Is.True, "New User Signup label should be visible.");

        await this._authorizePage.FillNameAsync(TestConstants.Authentication.UserName);
        await this._authorizePage.FillEmailAsync(TestConstants.Authentication.UserEmail);
        await this._authorizePage.ClickSignupButtonAsync();
    }

    private async Task FillAccountInformation()
    {
        var isEnterAccountInformationVisible = await this._accountInformationPage.IsEnterAccountInformationVisibleAsync();
        Assert.That(isEnterAccountInformationVisible, Is.True, "Enter Account Information label should be visible.");

        await this._accountInformationPage.ClickTitleMrRadioButtonAsync();
        await this._accountInformationPage.FillPasswordAsync(TestConstants.Authentication.Password);
        await this._accountInformationPage.SelectDateOfBirthAsync(
            TestConstants.DateOfBirth.Day,
            TestConstants.DateOfBirth.Month,
            TestConstants.DateOfBirth.Year
        );
        await this._accountInformationPage.ClickNewsletterCheckboxAsync();
        await this._accountInformationPage.ClickSpecialOffersCheckboxAsync();

        await this._accountInformationPage.FillPersonalNameAsync(
            TestConstants.PersonalInfo.FirstName,
            TestConstants.PersonalInfo.LastName
        );
        await this._accountInformationPage.FillCompanyAsync(TestConstants.PersonalInfo.Company);

        await this._accountInformationPage.FillAddressAsync(
            TestConstants.Address.Address1,
            TestConstants.Address.Address2
        );
        await this._accountInformationPage.SelectCountryAsync(TestConstants.Address.Country);
        await this._accountInformationPage.FillLocationDetailsAsync(
            TestConstants.Address.State,
            TestConstants.Address.City,
            TestConstants.Address.ZipCode
        );
        await this._accountInformationPage.FillPhoneNumberAsync(TestConstants.PersonalInfo.PhoneNumber);

        await this._accountInformationPage.ClickCreateAccountButtonAsync();
    }

    private async Task VerifyAccountCreatedAndLogin()
    {
        var isAccountCreatedVisible = await this._accountCreatedPage.IsAccountCreatedLabelVisibleAsync();
        Assert.That(isAccountCreatedVisible, Is.True, "Account Created label should be visible.");

        await this._accountCreatedPage.ClickContinueButtonAsync();

        var isLoggedInLabelVisible = await this._accountCreatedPage.IsLoggedInLabelVisibleAsync();
        Assert.That(isLoggedInLabelVisible, Is.True, "Logged in label should be visible.");
    }

    private async Task DeleteAccount()
    {
        await this._accountCreatedPage.ClickDeleteAccountButtonAsync();

        var isAccountDeleted = await this._accountCreatedPage.IsDeleteAccountButtonVisibleAsync();
        Assert.That(isAccountDeleted, Is.False, "Delete Account button should not be visible after account deletion.");
    }

    #endregion
}