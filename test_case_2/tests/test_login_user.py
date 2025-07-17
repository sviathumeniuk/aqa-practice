from playwright.sync_api import Page
from pages.home_page import HomePage
from pages.login_page import LoginPage
from pages.account_page import AccountPage
from pages.delete_page import DeletePage
from test_data.user_data import UserData

def test_login_user(page: Page):

    home_page = HomePage(page)
    login_page = LoginPage(page)
    account_page = AccountPage(page)
    delete_page = DeletePage(page)

    navigate_to_login_page(home_page)
    perform_invalid_login(login_page)
    verify_and_delete_account(account_page, delete_page)


def navigate_to_login_page(page: HomePage):
    page.navigate()
    page.verify_home_page()
    page.click_signup_login()
    
def perform_invalid_login(page: LoginPage):
    page.verify_login_page()
    page.login(UserData.VALID_EMAIL, UserData.VALID_PASSWORD)

def verify_and_delete_account(account_page: AccountPage, delete_page: DeletePage):
    account_page.verify_logged_in()
    account_page.click_delete_account()
    delete_page.verify_account_deleted()