Feature: Dropdown Page
	As a user,
	I want to be able to use a dropdown list,
	so that I can switch between a given set of options on the website.

Background:
	Given the user is on the Dropdown page

Scenario: The dropdown list does not select an option without user input
	Then the dropdown list should display the following text "Please select an option"

Scenario: The dropdown list displays the selected option of the user
	When the user selects Option <id> from the dropdown list
	Then the dropdown list should display the following text "Option "
