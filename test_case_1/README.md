# Test Case 1: User Registration

## Description
This test case verifies the complete user registration flow on the Automation Exercise website, including account creation and deletion.

## Test Steps

1. **Launch browser**
2. **Navigate to url** `http://automationexercise.com`
3. **Verify that home page is visible successfully**
4. **Click on 'Signup / Login' button**
5. **Verify 'New User Signup!' is visible**
6. **Enter name and email address**
7. **Click 'Signup' button**
8. **Verify that 'ENTER ACCOUNT INFORMATION' is visible**
9. **Fill details:** Title, Name, Email, Password, Date of birth
10. **Select checkbox** 'Sign up for our newsletter!'
11. **Select checkbox** 'Receive special offers from our partners!'
12. **Fill details:** First name, Last name, Company, Address, Address2, Country, State, City, Zipcode, Mobile Number
13. **Click 'Create Account' button**
14. **Verify that 'ACCOUNT CREATED!' is visible**
15. **Click 'Continue' button**
16. **Verify that 'Logged in as username' is visible**
17. **Click 'Delete Account' button**
18. **Verify that 'ACCOUNT DELETED!' is visible and click 'Continue' button**

## Expected Results
- User should be able to successfully register a new account
- All verification steps should pass
- Account should be created and then successfully deleted
- User should be logged in after account creation
- All page elements should be visible as expected

## Test Data Required
- Valid name
- Valid email address
- Password
- Personal information (address, phone, etc.)
- Date of birth

## Prerequisites
- Browser installed
- Internet connection
- Access