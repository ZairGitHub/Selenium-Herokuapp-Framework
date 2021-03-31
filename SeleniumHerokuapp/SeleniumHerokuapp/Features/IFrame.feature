Feature: iFrame Page
	As a user,
	I want to the website to support iFrames,
	so that I can interact with iFrame elements on the website.

Background:
	Given the user is on the iFrame Page

Scenario: iFrame can process interactions through text input
	When the user enters the text "input" using their keyboard
	Then the iFrame should append the input text to its default content text
