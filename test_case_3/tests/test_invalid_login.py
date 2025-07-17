import pytest
from playwright.sync_api import Page
from pages.home_page import HomePage
from pages.login_page import LoginPage
from test_data.user_data import UserData

def test_login_with_invalid_credentials(page: Page):

    home_page = HomePage(page)
    login_page = LoginPage(page)

    navigate_to_login_page(home_page)
    perform_invalid_login(login_page)
    
    
def navigate_to_login_page(page: HomePage):
    page.navigate_to_home(UserData.BASE_URL)
    page.verify_home_page()
    page.click_signup_login()
    
def perform_invalid_login(page: LoginPage):
    page.verify_login_form_visible()
    page.enter_login_credentials(UserData.INVALID_EMAIL, UserData.INVALID_PASSWORD)
    page.click_login_button()
    page.verify_error_message()