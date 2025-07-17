from pages.base_page import BasePage
from playwright.sync_api import expect

class HomePage(BasePage):

    SIGN_UP_LOGIN_LINK: str = "a[href='/login']"
    BODY: str = "body"
    TITLE: str = "Automation Exercise"
    
    def navigate_to_home(self, url: str):
        self.navigate_to(url)
                
    def verify_home_page(self):
        expect(self.page).to_have_title(self.TITLE)
        expect(self.page.locator(self.BODY)).to_be_visible()
    
    def click_signup_login(self):
        self.click_element(self.page.locator(self.SIGN_UP_LOGIN_LINK))