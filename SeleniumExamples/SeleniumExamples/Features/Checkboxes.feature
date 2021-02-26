Feature: Checkboxes
	As a user,
	I want to be toggle the state of checkboxes,
	so that I can interact with checkbox elements on the website.

Background:
	Given the user is on the Checkboxes page

Scenario Outline: Toggle checkboxes
	And the user toggles the checkbox <id>
	When the user checks the checkbox <id> state
	Then the checkbox state should be toggled
	Examples:
	| id |
	| 1  |
	| 2  |
