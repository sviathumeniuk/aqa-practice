using Microsoft.Playwright;

namespace test_case_1.Pages
{
    public class AccountCreatedPage : BasePage
    {
        public AccountCreatedPage(IPage page) : base(page)
        {
        }

        private ILocator AccountCreatedLabel => _page.Locator("h2[data-qa='account-created']");
        private ILocator ContinueButton => _page.Locator("a[data-qa='continue-button']");
        private ILocator LoggedInLabel => _page.Locator("li:has-text('Logged in as')");
        private ILocator DeleteAccountButton => _page.Locator("a[href='/delete_account']");

        public Task<bool> IsAccountCreatedLabelVisibleAsync()
        {
            return IsElementVisibleAsync(AccountCreatedLabel);
        }

        public Task ClickContinueButtonAsync()
        {
            return ClickElementAsync(ContinueButton);
        }

        public Task<bool> IsLoggedInLabelVisibleAsync()
        {
            return IsElementVisibleAsync(LoggedInLabel);
        }

        public Task ClickDeleteAccountButtonAsync()
        {
            return ClickElementAsync(DeleteAccountButton);
        }

        public Task<bool> IsDeleteAccountButtonVisibleAsync()
        {
            return IsElementVisibleAsync(DeleteAccountButton);
        }
    }
}