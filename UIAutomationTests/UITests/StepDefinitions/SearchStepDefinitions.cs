using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TSBAssessment.UITests.PageObjects;
using UIAutomationTests.UITests.PageObjects;

namespace UIAutomationTests.UITests.StepDefinitions
{
    [Binding]
    public class SearchStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private SearchPage searchPage;

        public SearchStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            searchPage = new SearchPage(driver);
        }

        [Given(@"I am on the TradeMe homepage")]
        public void GivenIAmOnTheTradeMeHomepage_()
        {
            loginPage.NavigateToTradeMeSandboxPage();
        }

        [When(@"I click on Browse dropdown and select a ""([^""]*)""")]
        public void WhenIClickOnBrowseDropdownAndSelectA(string category)
        {
            searchPage.BrowseDropdown.Click();
            var Item = searchPage.DropdownItems.FirstOrDefault(a => a.Text.Contains(category, StringComparison.OrdinalIgnoreCase));
            Item.Click();

        }

        [When(@"I enter ""([^""]*)"" into the search bar")]
        public void WhenIEnterIntoTheSearchBar_(string Item)
        {
            searchPage.SearchBar.SendKeys(Item);
            searchPage.SearchBar.Click();

        }

        [When(@"I click on the search icon")]
        public void WhenIClickOnTheSearchIcon_()
        {
            searchPage.SearchButton.Click();
        }

        [Then(@"I should see a list of search results related to ""([^""]*)""")]
        public void ThenIShouldSeeAListOfSearchResultsRelatedTo(string nike)
        {


            searchPage.ResultTxt.Click();
            string s = searchPage.GetText();
            Console.WriteLine(s);
            //Assert.IsTrue(searchPage.GetText().Contains("Showing 4 results for 'nike'"));


        }
    }
}
