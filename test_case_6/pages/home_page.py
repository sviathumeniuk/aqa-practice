from selenium.webdriver.common.by import By
from pages.base_page import BasePage

class HomePage(BasePage):
    
    BODY = (By.TAG_NAME, "body")
    CONTACT_US_LINK = (By.CSS_SELECTOR, "a[href='/contact_us']")
    
    def is_page_loaded(self) -> bool:
        return self.is_visible(self.BODY)

    def click_contact_us(self):
        self.click_element(self.CONTACT_US_LINK)