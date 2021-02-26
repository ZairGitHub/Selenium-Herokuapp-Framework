Feature: Hovers Page
	As a user,
	I want to be hover over elements to reveal new elements,
	so that I can interact with hidden elements on the website.

Background:
    Given the user is on the Hovers page

Scenario Outline: Hovering over an image reveals additional name information
	When the user hovers over the image <id>
	Then the user should be able to see additional name information for the image <id>
    Examples:
	| id |
	| 1  |
	| 2  |
	| 3  |
