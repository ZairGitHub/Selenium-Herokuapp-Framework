Feature: Broken Images Page
	As a user,
	I want to be able to detect broken images,
	so that I can differentiate between normal and broken images.

Background:
	Given the user is on the Broken Images page

Scenario Outline: Broken images are correctly detected
	When the user checks if an image is broken
	Then the condition of the image should reflect this information
	Examples:
	| id | condition |
	| 1  | true		 |
	| 2  | true		 |
	| 3  | false	 |
