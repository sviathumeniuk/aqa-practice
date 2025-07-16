using Microsoft.Playwright;

namespace test_case_1.Pages
{
    public abstract class BasePage
    {
        protected IPage _page;
        protected BasePage(IPage page)
        {
            _page = page;
        }

        protected async Task NavigateToAsync(string url)
        {
            await _page.GotoAsync(url);
        }

        protected static async Task<bool> IsElementVisibleAsync(ILocator locator)
        {
            return await locator.IsVisibleAsync();
        }

        protected static async Task ClickElementAsync(ILocator locator)
        {
            await locator.ClickAsync();
        }

        protected static async Task FillInputAsync(ILocator locator, string value)
        {
            await locator.FillAsync(value);
        }

        protected static async Task SelectOptionAsync(ILocator locator, string value)
        {
            await locator.SelectOptionAsync(value);
        }

        protected static async Task CheckElementAsync(ILocator locator)
        {
            await locator.CheckAsync();
        }
    }
}