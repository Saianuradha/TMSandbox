Feature: Selling

Verify the process of listing an item under a general classification through the selling interface.

@run
Scenario:SC01_Listing an Item before login into account
	Given I am on the TradeMe homepage
	And I login into my account with valid credentials
	When I click on start a listing link
	And I select General item link
	And I select Item for listing
	And I sucessfully navigate to pricing
	And I enter price details 
	Then I navigate to confirmation page
	And I should see Auction is started message

@run
Scenario:SC02_Listing an Item before login into account
	Given I am on the TradeMe homepage
	When I click on start a listing link
	And I select General item link
	And I login into my account with valid credentials
	And I select Item for listing
	And I sucessfully navigate to pricing
	And I enter price details 
	Then I navigate to confirmation page
	And I should see Auction is started message
