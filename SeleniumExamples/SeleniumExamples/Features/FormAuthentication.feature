Feature: Form Authentication Page
	As a user,
	I want to be able to authenticate my credentials,
	so that I can access the Secure Area page.

Background:
	Given the user is on the Form Authentication page

Scenario: Logging in with no credentials displays a username error message
	When the user clicks the login button
	Then a help message containing the following text "Your username is invalid!" should be displayed

Scenario: Logging in with a valid username and no password displays a password error message
    When the user enters a valid username
    And the user clicks the login button
    Then a help message containing the following text "Your password is invalid!" should be displayed

Scenario: Logging in with a valid username and a valid password redirects user to the Secure Area page
    When the user enters a valid username
    And the user enters a valid password
    And the user clicks the login button
    Then a help message containing the following text "You logged into a secure area!" should be displayed

Scenario: Directly navigating to the Secure Area page displays an appropriate error message
    When the user directly navigates to the Secure Area page
    Then a help message containing the following text "You must login to view the secure area!" should be displayed

Scenario: Logging out redirects the user back to the Form Authentication page
    When the user is logged in
    And the user clicks the logout button
    Then a help message containing the following text "You logged out of the secure area!" should be displayed
