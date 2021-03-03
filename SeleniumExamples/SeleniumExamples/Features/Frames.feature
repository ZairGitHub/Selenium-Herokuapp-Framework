Feature: Frames Page
	As a user,
	I want to be able to select links on the frames page,
	so that I can navigate to other areas of the website.

Background:
	Given the user is on the Frames page

Scenario: Navigate to Nested Frames page
	When the user clicks the NestedFrames link
	Then the page url should inform the user that they are on the correct "nested_frames" page

Scenario: Navigate to iFrames page
	When the user clicks the iFrames link
	Then the page header text should inform the user that they are on the correct "An iFrame containing the TinyMCE WYSIWYG Editor" page
