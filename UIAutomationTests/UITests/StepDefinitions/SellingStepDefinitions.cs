using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TSBAssessment.UITests.PageObjects;
using UIAutomationTests.UITests.PageObjects;

namespace UIAutomationTests.UITests.StepDefinitions
{
    [Binding]
    public class SellingStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private SearchPage searchPage;
        private SellingPage sellingPage;
        private ListingPage listingPage;

        public SellingStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            searchPage = new SearchPage(driver);
            sellingPage = new SellingPage(driver);
            listingPage = new ListingPage(driver);
        }

        [When(@"I click on start a listing link")]
        public void WhenIClickOnStartAListingLink()
        {
            sellingPage.ListingLink.Click();
            Assert.That(sellingPage.ListAnItemHeading.Displayed);
        }

        [When(@"I select General item link")]
        public void WhenISelectGeneralItemLink()
        {
            sellingPage.GeneralItemLink.Click();
        }
        [Given(@"I login into my account with valid credentials")]
        public void GivenILoginIntoMyAccountWithValidCredentials()
        {
            loginPage.LogIn("validEmail", "validPassword");
            Assert.IsTrue(loginPage.IsLoggedIn(), "Login unsuccessful");
            Assert.IsTrue(loginPage.GetPageHeading().Contains("Home page"));
        }

        [When(@"I select Item for listing")]
        public void WhenISelectItemForListing()
        {
            listingPage.searchForAnItem("item");
        }

        [When(@"I sucessfully navigate to pricing")]
        public void WhenISucessfullyNavigateToPricing()
        {
            throw new PendingStepException();
        }

        [When(@"I enter price details")]
        public void WhenIEnterPriceDetails()
        {
            throw new PendingStepException();
        }

        [Then(@"I navigate to confirmation page")]
        public void ThenINavigateToConfirmationPage()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see Auction is started message")]
        public void ThenIShouldSeeAuctionIsStartedMessage()
        {
            throw new PendingStepException();
        }

        [When(@"I login into my account with valid credentials")]
        public void WhenILoginIntoMyAccountWithValidCredentials()
        {
            throw new PendingStepException();
        }

    }
}
