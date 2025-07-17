from playwright.sync_api import expect, Page

class LoginPage:

    LOGIN_HEADER: str = "h2:has-text('Login to your account')"
    EMAIL_INPUT: str = "input[data-qa='login-email']"
    PASSWORD_INPUT: str = "input[data-qa='login-password']"
    LOGIN_BUTTON: str = "button[data-qa='login-button']"

    def __init__(self, page: Page):
        self.page = page

    def verify_login_page(self):
        expect(self.page.locator(self.LOGIN_HEADER)).to_be_visible()

    def login(self, email: str, password: str):
        self.page.locator(self.EMAIL_INPUT).fill(email)
        self.page.locator(self.PASSWORD_INPUT).fill(password)
        self.page.locator(self.LOGIN_BUTTON).click()