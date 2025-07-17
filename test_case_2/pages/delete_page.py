from playwright.sync_api import Page, expect

class DeletePage:

    ACCOUNT_DELETED_HEADER: str = "h2:has-text('Account Deleted!')"

    def __init__(self, page: Page):
        self.page = page

    def verify_account_deleted(self):
        expect(self.page.locator(self.ACCOUNT_DELETED_HEADER)).to_be_visible()