Feature: Index Page Navigation
	As a user,
	I want to be able to select links on the index page,
	so that I can navigate to other areas of the website

Background:
	Given I am on the Index page

Scenario: Add/Remove Elements Page
	When I click the Add/Remove Elements link
	And I read the page header text
	Then the text should inform me that I am on the Add/Remove Elements Page
