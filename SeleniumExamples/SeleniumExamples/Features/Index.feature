Feature: Index Page Navigation
	As a user,
	I want to be able to select links on the index page,
	so that I can navigate to other areas of the website.

Background:
	Given the user is on the Index page

@external-website
Scenario: Navigate to Elemental Selenium website
	When the user clicks the link in the footer of the page
	And the user switches to the newly created tab 1
	Then the page url should indicate that the user has been redirected to the correct "http://elementalselenium.com/" website 

@external-website
Scenario: Navigate to GitHub website repository
	When the user clicks the GitHub image
	Then the page url should indicate that the user has been redirected to the correct "https://github.com/saucelabs/the-internet" website 

Scenario: Navigate to Add/Remove Elements page
	When the user clicks the Add/Remove Elements link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "Add/Remove Elements" page

@ignore
Scenario: Navigate to Basic Authentication form
	When the user clicks the Basic Authentication link
	And the user reads the popup text
	Then the text should inform the user that they are attempting to reach the correct "“Restricted Area”" page

Scenario: Navigate to Checkboxes page
	When the user clicks the Checkboxes link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "Checkboxes" page

@ignore
Scenario: Navigate to Digest Authentication form
	When the user clicks the Digest Authentication link
	And the user reads the popup text
	Then the text should inform the user that they are attempting to reach the correct "“Protected Area”" page

Scenario: Navigate to Form Authentication page
	When the user clicks the Form Authentication link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "Login Page" page

Scenario: Navigate to Hovers page
	When the user clicks the Hovers link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "Hovers" page

Scenario: Navigate to JavaScript Alerts page
	When the user clicks the JavaScript Alerts link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "JavaScript Alerts" page
