Feature: Add/Remove Elements
	As a user,
	I want to be able to add and remove elements,
	so that I can create and delete elements on the website.

Background:
	Given the user is on the Add/Remove page

Scenario: Add Button
	When the user clicks the add button
	And the user clicks the add button
	And the user clicks the add button
	And the user counts the number of delete buttons
	Then the number of delete buttons should be equal to 3
