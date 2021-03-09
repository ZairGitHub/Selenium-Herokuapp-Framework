Feature: Drag and Drop Page
	As a user,
	I want to be able to pick up and move elements,
	so that I can drag and drop elements on the website.

Background:
	Given the user is on the Drag and Drop Page

Scenario: Dragging a draggable element over another draggable element swaps their positions
	And I drag a draggable element and drop it on top of another draggable element
	Then the contents of the elements should be swapped "true"
