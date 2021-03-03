Feature: Nested Frames Page
	As a user,
	I want to be able to distinguish between frames on the same page,
	so that I can interact with different frames on the website.

Background:
	Given the user is on the Nested Frames page

@frame-text
Scenario: Left frame displays the correct text
	When the user switches to the left frame
	Then the body of the frame should display the correct text "LEFT"

@frame-text
Scenario: Middle frame displays the correct text
	When the user switches to the middle frame
	Then the body of the frame should display the correct text "MIDDLE"

@frame-text
Scenario: Right frame displays the correct text
	When the user switches to the right frame
	Then the body of the frame should display the correct text "RIGHT"

@frame-text
Scenario: Bottom frame displays the correct text
	When the user switches to the bottom frame
	Then the body of the frame should display the correct text "BOTTOM"
	
@frame-border
Scenario Outline: Top and bottom parent frames can be resized using their shared border
	When the user resizes the top and bottom parent frames using their shared border <offset>
	Then the sizes of the parent frames should be different to their original sizes
	Examples:
	| offset |
	| -50	 |
	| 50	 |

@frame-border
Scenario Outline: Left and middle nested frames can be resized using their shared border
	When the user resizes the left and middle nested frames using their shared border <offset>
	Then the sizes of the nested frames should be different to their original sizes
	Examples:
	| offset |
	| -50	 |
	| 50	 |

@frame-border
Scenario Outline: Right and middle nested frames can be resized using their shared border
	When the user resizes the right and middle nested frames using their shared border <offset>
	Then the sizes of the nested frames should be different to their original sizes
	Examples:
	| offset |
	| -50	 |
	| 50	 |
