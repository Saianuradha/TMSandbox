Feature: Search

A short summary of the feature

@tag1
Scenario Outline: Basic Product Search
Given I am on the TradeMe homepage.
When I click on Browse dropdown and select a <category>
And I enter <search item> into the search bar.
And I click on the search icon.
Then I should see a list of search results related to <search item>

Examples: 
| category | search item |
|"Computers" |   "Nike"   |