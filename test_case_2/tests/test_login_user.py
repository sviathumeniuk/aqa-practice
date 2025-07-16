from playwright.sync_api import Page, expect
from pages.home_page import HomePage
from pages.login_page import LoginPage
from pages.account_page import AccountPage
from pages.delete_page import DeletePage
from test_data.user_data import UserData

class TestLoginUser:
    def test_login_user(self, page: Page):

        home_page = HomePage(page)
        login_page = LoginPage(page)
        account_page = AccountPage(page)
        delete_page = DeletePage(page)
        
        home_page.navigate()
        home_page.verify_home_page()
        
        home_page.click_signup_login()
        
        login_page.verify_login_page()

        login_page.login(UserData.VALID_EMAIL, UserData.VALID_PASSWORD)

        account_page.verify_logged_in()
        
        account_page.click_delete_account()
        
        delete_page.verify_account_deleted()