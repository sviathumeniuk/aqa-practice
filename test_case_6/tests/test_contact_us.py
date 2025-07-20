import os
import sys
import pytest
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from webdriver_manager.chrome import ChromeDriverManager

sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from pages.home_page import HomePage
from pages.contact_us_page import ContactUsPage
from test_data.user_data import UserData


class TestContactUs:
    
    @pytest.fixture(autouse=True)
    def setup(self):
        self.driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()))
        self.driver.maximize_window()
        self.driver.implicitly_wait(10)
        yield
        self.driver.quit()
    
    def test_contact_us_form_submission(self):
        self.driver.get(UserData.BASE_URL)
        
        home_page = HomePage(self.driver)
        contact_page = ContactUsPage(self.driver)
        
        assert home_page.is_page_loaded(), "Home page is not loaded"
        
        home_page.click_contact_us()

        assert contact_page.is_get_in_touch_visible(), "Get In Touch header is not visible"

        contact_page.fill_contact_form(
            name=UserData.NAME,
            email=UserData.EMAIL,
            subject=UserData.SUBJECT,
            message=UserData.MESSAGE
        )
        
        contact_page.upload_file()
        
        contact_page.submit_form()
        
        assert contact_page.is_success_message_visible(), "Success message is not visible"
        
        contact_page.click_home_button()
        assert home_page.is_page_loaded(), "Home page is not loaded after form submission"