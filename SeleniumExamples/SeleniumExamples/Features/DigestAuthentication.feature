Feature: Digest Authentication Form
	As a user,
	I want to be able to authenticate my credentials,
	so that I can access the Digest Authentication page.

@ignore
Scenario: Cancel button cancels authentication
    Given the user is on the Digest Authentication form with no credentials
	When the user clicks the cancel button
	Then the page header text should inform the user that their credentials could not be authenticated ""

Scenario: OK button redirects to authentication page with valid credentials
    Given the user is on the Digest Authentication form with valid credentials
    Then the page header text should inform the user that their credentials have successfully been authenticated "Digest Auth"

Scenario: Successful authenticatation persists within window browser
    Given the user is on the Digest Authentication form with valid credentials
    When the user opens a new tab and closes their previous tab
    And the user navigates to the Digest Authentication form with no credentials
    Then the page header text should inform the user that their credentials have successfully been authenticated "Digest Auth"
