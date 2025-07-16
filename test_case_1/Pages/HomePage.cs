using Microsoft.Playwright;

namespace test_case_1.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IPage page) : base(page)
        {
        }

        private ILocator SignupLoginButton => _page.Locator("a[href='/login']");
        private ILocator HomePageContent => _page.Locator(".features_items");

        public Task NavigateToHomePageAsync(string url)
        {
            return _page.GotoAsync(url);
        }

        public Task ClickSignupLoginButtonAsync()
        {
            return ClickElementAsync(SignupLoginButton);
        }

        public Task<bool> IsHomePageContentVisibleAsync()
        {
            return IsElementVisibleAsync(HomePageContent);
        }
    }
}