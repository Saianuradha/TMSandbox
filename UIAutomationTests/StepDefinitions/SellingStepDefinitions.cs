using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using UIAutomationTests.PageObjects;

namespace UIAutomationTests.StepDefinitions
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
            this.loginPage = new LoginPage(driver);
            this.searchPage = new SearchPage(driver);
            this.sellingPage = new SellingPage(driver);
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
