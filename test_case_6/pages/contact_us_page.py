import os
from selenium.webdriver.common.by import By
from pages.base_page import BasePage
from test_data.user_data import UserData

class ContactUsPage(BasePage):
    
    GET_IN_TOUCH_HEADER = (By.XPATH, "//h2[text()='Get In Touch']")
    NAME_FIELD = (By.CSS_SELECTOR, "[data-qa='name']")
    EMAIL_FIELD = (By.CSS_SELECTOR, "[data-qa='email']")
    SUBJECT_FIELD = (By.CSS_SELECTOR, "[data-qa='subject']")
    MESSAGE_FIELD = (By.CSS_SELECTOR, "[data-qa='message']")
    FILE_FIELD = (By.CSS_SELECTOR, "input[type='file']")
    SUBMIT_BUTTON = (By.CSS_SELECTOR, "[data-qa='submit-button']")
    SUCCESS_MESSAGE = (By.CSS_SELECTOR, ".status.alert.alert-success")
    HOME_BUTTON = (By.CSS_SELECTOR, ".btn.btn-success")

    def is_get_in_touch_visible(self) -> bool:
        return self.is_visible(self.GET_IN_TOUCH_HEADER)
    
    def fill_contact_form(self, name: str, email: str, subject: str, message: str):
        self.enter_text(self.NAME_FIELD, name)
        self.enter_text(self.EMAIL_FIELD, email)
        self.enter_text(self.SUBJECT_FIELD, subject)
        self.enter_text(self.MESSAGE_FIELD, message)
    
    def upload_file(self):
        base_dir = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
        file_path = os.path.join(base_dir, "test_data", UserData.TEST_FILE)
        self.get_element(self.FILE_FIELD).send_keys(file_path)

    def submit_form(self):
        self.click_element(self.SUBMIT_BUTTON)
        self.wait_for_alert_and_accept()
        
    def is_success_message_visible(self) -> bool:
        return self.is_visible(self.SUCCESS_MESSAGE)
    
    def click_home_button(self):
        self.click_element(self.HOME_BUTTON)