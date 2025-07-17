from pages.base_page import BasePage
from playwright.sync_api import expect

class LoginPage(BasePage):
    LOGIN_FORM_TITLE: str = "h2:text('Login to your account')"
    EMAIL_INPUT: str = "input[data-qa='login-email']"
    PASSWORD_INPUT: str = "input[data-qa='login-password']"
    LOGIN_BUTTON: str = "button[data-qa='login-button']"
    ERROR_MESSAGE: str = "p:text('Your email or password is incorrect!')"
    
    def verify_login_form_visible_async(self):
        expect(self.page.locator(self.LOGIN_FORM_TITLE)).to_be_visible()
        
    def enter_login_credentials_async(self, email: str, password: str):
        self.fill_input_async(self.page.locator(self.EMAIL_INPUT), email)
        self.fill_input_async(self.page.locator(self.PASSWORD_INPUT), password)
        
    def click_login_button_async(self):
        self.click_element_async(self.page.locator(self.LOGIN_BUTTON))
        
    def verify_error_message_async(self):
        expect(self.page.locator(self.ERROR_MESSAGE)).to_be_visible()