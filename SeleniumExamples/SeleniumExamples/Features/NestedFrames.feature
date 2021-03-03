Feature: Nested Frames Page
	As a user,
	I want to be able to distinguish between frames on the same page,
	so that I can interact with different frames on the website.

Background:
	Given the user is on the Nested Frames page

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120