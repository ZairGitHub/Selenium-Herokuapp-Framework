Feature: Basic Authentication Form
	As a user,
	I want to be able to authenticate my credentials,
	so that I can access the Basic Authentication page.

Background:
    Given the user is on the Basic Authentication Form

@ignore
Scenario: Cancel button cancels authentication
	When the user clicks the cancel button
	Then the page header text should inform the user that they failed to authenticate their credentials
