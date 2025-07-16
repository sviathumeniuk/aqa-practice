using Microsoft.Playwright;

namespace test_case_1.Pages
{
    public class AuthorizePage : BasePage
    {
        public AuthorizePage(IPage page) : base(page)
        {
        }

        private ILocator NewUserSignupLabel => _page.Locator("h2:has-text('New User Signup!')");
        private ILocator NameField => _page.Locator("input[data-qa='signup-name']");
        private ILocator EmailField => _page.Locator("input[data-qa='signup-email']");
        private ILocator SignupButton => _page.Locator("button[data-qa='signup-button']");

        public Task<bool> IsNewUserSignupVisibleAsync()
        {
            return IsElementVisibleAsync(NewUserSignupLabel);
        }

        public Task FillNameAsync(string name)
        {
            return FillInputAsync(NameField, name);
        }

        public Task FillEmailAsync(string email)
        {
            return FillInputAsync(EmailField, email);
        }

        public Task ClickSignupButtonAsync()
        {
            return SignupButton.ClickAsync();
        }
    }
}