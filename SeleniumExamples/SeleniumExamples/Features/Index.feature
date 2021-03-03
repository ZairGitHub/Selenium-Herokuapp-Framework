Feature: Index Page
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

@hypertext
Scenario: Navigate to Add/Remove Elements page
	When the user clicks the Add/Remove Elements link
	Then the page header text should inform the user that they are on the correct "Add/Remove Elements" page

@ignore @authentication-popup
Scenario: Navigate to Basic Authentication form
	When the user clicks the Basic Authentication link
	Then the popup text should inform the user that they are attempting to reach the correct "“Restricted Area”" page

@hypertext
Scenario: Navigate to Checkboxes page
	When the user clicks the Checkboxes link
	Then the page header text should inform the user that they are on the correct "Checkboxes" page

@ignore @authentication-popup
Scenario: Navigate to Digest Authentication form
	When the user clicks the Digest Authentication link
	Then the popup text should inform the user that they are attempting to reach the correct "“Protected Area”" page

@hypertext
Scenario: Navigate to Form Authentication page
	When the user clicks the Form Authentication link
	Then the page header text should inform the user that they are on the correct "Login Page" page

@hypertext
Scenario: Navigate to Frames page
	When the user clicks the Frames link
	Then the page header text should inform the user that they are on the correct "Frames" page

@hypertext
Scenario: Navigate to Hovers page
	When the user clicks the Hovers link
	Then the page header text should inform the user that they are on the correct "Hovers" page

@hypertext
Scenario: Navigate to JavaScript Alerts page
	When the user clicks the JavaScript Alerts link
	Then the page header text should inform the user that they are on the correct "JavaScript Alerts" page

@hypertext
Scenario: Navigate to Nested Frames page
	When the user clicks the Nested Frames link
	Then the page url should inform the user that they are on the correct "nested_frames" page
