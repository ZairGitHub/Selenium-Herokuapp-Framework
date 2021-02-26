Feature: DigestAuthentication
	As a user,
	I want to be able to authenticate my credentials,
	so that I can access the Digest Authentication page.

@ignore
Scenario: Cancel button cancels authentication
    Given the user is on the Digest Authentication form with no credentials
	When the user clicks the cancel button
	Then the page header text should inform the user that their credentials could not be authenticated ""
