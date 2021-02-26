Feature: JavaScriptAlerts Page
	As a user,
	I want to be to handle information from within JavaScript alerts,
	so that I interact with JavaScript alerts on the website.

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120