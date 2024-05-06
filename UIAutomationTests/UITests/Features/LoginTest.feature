Feature: LoginTests

Demonstrate appropriate test cases for customer login scenarios and login page validation.

Background: 
Given I'm on TradeMe home page
And I click on the login link

@run
Scenario:SC01_Successful Login	
	When I enter Email and password
	And click on the signin button
	Then home page is displayed
@run
Scenario:SC02_Invalid Username
	When I enter invalid email and valid password
	And click on the signin button
	Then the system should display an error message indicating that the username is incorrect

@run
Scenario:SC03_Invalid Password
	When I enter email and Invalid password
	And click on the signin button
	Then the system should display an error message indicating that the password is incorrect

@run
Scenario:SC04_Blank Email and Password
	When I leave both email and password fields blank
	And click on the signin button
	Then the system should display an error message indicating that the both username and password are required

@run
Scenario:SC05_Forgot Password Link
	When I click on the Forgot Password link
	Then the system should be redirected to the password reset page where they can reset their password

@run
Scenario:SC06_RememberMe Functionality
	Given I checked the "Remember Me" checkbox during login
	When I closes and reopens the browser
	Then I should be automatically logged in without having to enter credentials again





