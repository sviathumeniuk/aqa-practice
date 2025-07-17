# Test Case 3: Login User with incorrect email and password

## Description
This test case verifies the login error handling on the Automation Exercise website when a user attempts to login with incorrect credentials.

## Test Steps

1. **Launch browser**
2. **Navigate to url** `http://automationexercise.com`
3. **Verify that home page is visible successfully**
4. **Click on 'Signup / Login' button**
5. **Verify 'Login to your account' is visible**
6. **Enter incorrect email address and password**
7. **Click 'login' button**
8. **Verify error 'Your email or password is incorrect!' is visible**

## Expected Results
- Home page should load properly
- Login form should be accessible
- Error message should be displayed when incorrect credentials are submitted
- User should not be authenticated
- All verification steps should pass

## Test Data Required
- Invalid email address (non-registered or incorrectly formatted)
- Invalid password

## Prerequisites
- Browser installed
- Internet connection
- Access to http://automationexercise.com