Feature: Index
	As a user,
	I want to be able to select links on the index page,
	so that I can navigate to other areas of the website

Background:
	Given I am on the Index page

Scenario: Add/Remove Elements Page
	When I click the Add/Remove Elements link
	Then I should be redirected to the Add/Remove Elements Page
