Feature: Index Page Navigation
	As a user,
	I want to be able to select links on the index page,
	so that I can navigate to other areas of the website

Background:
	Given the user is on the Index page

Scenario: Add/Remove Elements Page
	When the user clicks the Add/Remove Elements link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "Add/Remove Elements" page

Scenario: Basic Authentication Form
	When the user clicks the Basic Authentication Link
	And the user reads the popup text
	Then the text should inform the user that they are attempting to reach the correct "“Restricted Area”" page

Scenario: Checkboxes Page
	When the user clicks the Checkboxes link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "Checkboxes" page

Scenario: Digest Authentication Form
	When the user clicks the Digest Authentication Link
	And the user reads the popup text
	Then the text should inform the user that they are attempting to reach the correct "“Protected Area”" page
