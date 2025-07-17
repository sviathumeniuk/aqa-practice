from playwright.sync_api import expect, Page

class AccountPage:

    LOGGED_IN_INDICATOR: str = "text=Logged in as"
    DELETE_ACCOUNT_LINK: str = "a[href='/delete_account']"

    def __init__(self, page: Page):
        self.page = page

    def verify_logged_in(self):
        expect(self.page.locator(self.LOGGED_IN_INDICATOR)).to_be_visible()

    def click_delete_account(self):
        self.page.locator(self.DELETE_ACCOUNT_LINK).click()