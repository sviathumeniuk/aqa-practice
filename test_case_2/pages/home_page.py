from playwright.sync_api import Page, expect
from test_data.user_data import UserData

class HomePage:

    SIGNUP_LOGIN_LINK: str = "a[href='/login']"
    BODY: str = "body"
    TITLE: str = "Automation Exercise"

    def __init__(self, page: Page):
        self.page = page

    def navigate(self):
        self.page.goto(UserData.BASE_URL)

    def verify_home_page(self):
        expect(self.page).to_have_title(self.TITLE)
        expect(self.page.locator(self.BODY)).to_be_visible()

    def click_signup_login(self):
        self.page.locator(self.SIGNUP_LOGIN_LINK).click()
