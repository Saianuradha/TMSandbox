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

        public SellingStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            searchPage = new SearchPage(driver);
            sellingPage = new SellingPage(driver);
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
    }
}
