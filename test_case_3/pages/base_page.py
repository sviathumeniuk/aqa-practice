from playwright.sync_api import Page, Locator

class BasePage:
    def __init__(self, page: Page):
        self.page = page
        
    def navigate_to_async(self, url: str):
        self.page.goto(url)

    def is_element_visible_async(self, locator: Locator) -> bool:
        return locator.is_visible()

    def click_element_async(self, locator: Locator):
        locator.click()

    def fill_input_async(self, locator: Locator, value: str):
        locator.fill(value)

    def select_option_async(self, locator: Locator, value: str):
        locator.select_option(value)

    def check_element_async(self, locator: Locator):
        locator.check()