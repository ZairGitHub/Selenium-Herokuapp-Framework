Feature: Index Page Navigation
	As a user,
	I want to be able to select links on the index page,
	so that I can navigate to other areas of the website.

Background:
	Given the user is on the Index page

Scenario: Elemental Selenium Website
	When the user clicks the link in the footer of the page
	And the user switches to the newly created tab 1
	And the user reads the page url
	Then the url should inform the user that they have been redirected to the correct "http://elementalselenium.com/" website 

Scenario: GitHub Website Repository
	When the user clicks the GitHub image
	And the user reads the page url
	Then the url should inform the user that they have been redirected to the correct "https://github.com/saucelabs/the-internet" website 

Scenario: Add/Remove Elements Page
	When the user clicks the Add/Remove Elements link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "Add/Remove Elements" page

@ignore
Scenario: Basic Authentication Form
	When the user clicks the Basic Authentication link
	And the user reads the popup text
	Then the text should inform the user that they are attempting to reach the correct "“Restricted Area”" page

Scenario: Checkboxes Page
	When the user clicks the Checkboxes link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "Checkboxes" page

@ignore
Scenario: Digest Authentication Form
	When the user clicks the Digest Authentication link
	And the user reads the popup text
	Then the text should inform the user that they are attempting to reach the correct "“Protected Area”" page

Scenario: Form Authentication Page
	When the user clicks the Form Authentication link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "Login Page" page

Scenario: Hovers Page
	When the user clicks the Hovers link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "Hovers" page

Scenario: JavaScript Alerts Page
	When the user clicks the JavaScript Alerts link
	And the user reads the page header text
	Then the text should inform the user that they are on the correct "JavaScript Alerts" page
