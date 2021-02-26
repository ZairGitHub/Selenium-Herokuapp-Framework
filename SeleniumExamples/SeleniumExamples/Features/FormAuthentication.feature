Feature: Form Authentication Page
	As a user,
	I want to be able to authenticate my credentials,
	so that I can access the Secure Area page.

Background:
	Given the user is on the Form Authentication page

Scenario: Log in button with no credentials displays a username error
	When the user clicks the login button
	Then an error message containing the following text "Your username is invalid!" should be displayed
