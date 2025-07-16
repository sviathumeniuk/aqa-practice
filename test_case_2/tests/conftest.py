from pathlib import Path
import sys
import pytest
from playwright.sync_api import BrowserContext, Page
from typing import Iterator

project_root = Path(__file__).parent.parent
sys.path.append(str(project_root))

@pytest.fixture
def page(context: BrowserContext) -> Iterator[Page]:
    page = context.new_page()
    yield page
    page.close()