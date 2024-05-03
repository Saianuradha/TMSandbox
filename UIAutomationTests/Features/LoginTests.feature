Feature: LoginTests

A short summary of the feature

@tag1
Scenario: Successful Login
	Given I'm on TradeMe login page
	When I click on the Login in button
	And I enter Email and password
	And I successfully validate the CAPTCHA
	And I click on Log in button
	Then home page is displayed

