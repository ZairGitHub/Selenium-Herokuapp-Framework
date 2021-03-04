Feature: Dropdown Page
	As a user,
	I want to be able to use a dropdown list,
	so that I can switch between a given set of options on the website.

Background:
	Given the user is on the Dropdown page

Scenario: The dropdown list initially informs the user of additonal options to select
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120