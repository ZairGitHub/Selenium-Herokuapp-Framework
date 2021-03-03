Feature: iFrame Page
	As a user,
	I want to be able to select links on the frames page,
	so that I can navigate to other areas of the website.

Background:
	Given the user is on the iFrame Page

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120