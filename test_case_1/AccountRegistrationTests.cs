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
        await _homePage.NavigateToHomePageAsync(TestConstants.Urls.BaseUrl);
        
        var isHomePageVisible = await _homePage.IsHomePageContentVisibleAsync();
        Assert.That(isHomePageVisible, Is.True, "Home page should be visible.");
    }

    private async Task SignUpNewUser()
    {
        await _homePage.ClickSignupLoginButtonAsync();

        var isNewUserSignupVisible = await _authorizePage.IsNewUserSignupVisibleAsync();
        Assert.That(isNewUserSignupVisible, Is.True, "New User Signup label should be visible.");

        await _authorizePage.FillNameAsync(TestConstants.Authentication.UserName);
        await _authorizePage.FillEmailAsync(TestConstants.Authentication.UserEmail);
        await _authorizePage.ClickSignupButtonAsync();
    }

    private async Task FillAccountInformation()
    {
        var isEnterAccountInformationVisible = await _accountInformationPage.IsEnterAccountInformationVisibleAsync();
        Assert.That(isEnterAccountInformationVisible, Is.True, "Enter Account Information label should be visible.");

        await _accountInformationPage.ClickTitleMrRadioButtonAsync();
        await _accountInformationPage.FillPasswordAsync(TestConstants.Authentication.Password);
        await _accountInformationPage.SelectDateOfBirthAsync(
            TestConstants.DateOfBirth.Day,
            TestConstants.DateOfBirth.Month,
            TestConstants.DateOfBirth.Year
        );
        await _accountInformationPage.ClickNewsletterCheckboxAsync();
        await _accountInformationPage.ClickSpecialOffersCheckboxAsync();

        await _accountInformationPage.FillPersonalNameAsync(
            TestConstants.PersonalInfo.FirstName,
            TestConstants.PersonalInfo.LastName
        );
        await _accountInformationPage.FillCompanyAsync(TestConstants.PersonalInfo.Company);
        
        await _accountInformationPage.FillAddressAsync(
            TestConstants.Address.Address1,
            TestConstants.Address.Address2
        );
        await _accountInformationPage.SelectCountryAsync(TestConstants.Address.Country);
        await _accountInformationPage.FillLocationDetailsAsync(
            TestConstants.Address.State,
            TestConstants.Address.City,
            TestConstants.Address.ZipCode
        );
        await _accountInformationPage.FillPhoneNumberAsync(TestConstants.PersonalInfo.PhoneNumber);

        await _accountInformationPage.ClickCreateAccountButtonAsync();
    }

    private async Task VerifyAccountCreatedAndLogin()
    {
        var isAccountCreatedVisible = await _accountCreatedPage.IsAccountCreatedLabelVisibleAsync();
        Assert.That(isAccountCreatedVisible, Is.True, "Account Created label should be visible.");

        await _accountCreatedPage.ClickContinueButtonAsync();

        var isLoggedInLabelVisible = await _accountCreatedPage.IsLoggedInLabelVisibleAsync();
        Assert.That(isLoggedInLabelVisible, Is.True, "Logged in label should be visible.");
    }

    private async Task DeleteAccount()
    {
        await _accountCreatedPage.ClickDeleteAccountButtonAsync();

        var isAccountDeleted = await _accountCreatedPage.IsDeleteAccountButtonVisibleAsync();
        Assert.That(isAccountDeleted, Is.False, "Delete Account button should not be visible after account deletion.");
    }

    #endregion
}