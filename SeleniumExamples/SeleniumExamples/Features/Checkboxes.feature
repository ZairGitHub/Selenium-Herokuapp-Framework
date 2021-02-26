Feature: Checkboxes Page
	As a user,
	I want to be toggle the state of checkboxes,
	so that I can interact with checkbox elements on the website.

Background:
	Given the user is on the Checkboxes page

Scenario Outline: Interacting with a checkbox toggles its state
	And the user clicks on a checkbox <id>
	Then the state of the checkbox <id> should be toggled
	Examples:
	| id |
	| 1  |
	| 2  |
