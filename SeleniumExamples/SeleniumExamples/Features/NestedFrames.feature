Feature: Nested Frames Page
	As a user,
	I want to be able to distinguish between frames on the same page,
	so that I can interact with different frames on the website.

Background:
	Given the user is on the Nested Frames page

@mytag
Scenario: Left frame displays the correct text
	When the user switches to the left frame
	Then the body of the frame should display the correct text "LEFT"
	