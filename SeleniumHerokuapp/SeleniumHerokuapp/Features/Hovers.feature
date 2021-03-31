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

Scenario Outline: Hovering over an image reveals a link for additional profile information
    When the user hovers over the image <id>
    And the user clicks the profile link
    Then the user should be redirected to a profile page for the selected user <id>
	Examples:
	| id |
	| 1  |
	| 2  |
	| 3  |
