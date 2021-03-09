Feature: Drag and Drop Page
	As a user,
	I want to be able to pick up and move elements,
	so that I can drag and drop elements on the website.

Background:
	Given the user is on the Drag and Drop Page

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120