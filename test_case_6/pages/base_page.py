from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.support.ui import WebDriverWait

class BasePage:
    def __init__(self, driver):
        self.driver = driver
        self.wait = WebDriverWait(driver, 10)
    
    def click_element(self, locator: str):
        self.wait.until(EC.element_to_be_clickable(locator)).click()
    
    def enter_text(self, locator: str, text: str):
        self.wait.until(EC.visibility_of_element_located(locator)).send_keys(text)
        
    def is_visible(self, locator: str) -> bool:
        try:
            WebDriverWait(self.driver, 10).until(
                EC.visibility_of_element_located(locator)
            )
            return True
        except Exception:
            return False
    
    def get_element(self, locator: str):
        return self.wait.until(EC.visibility_of_element_located(locator))
    
    def wait_for_alert_and_accept(self):
        alert = self.wait.until(EC.alert_is_present())
        alert.accept()