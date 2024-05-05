using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UIAutomationTests.UITests.PageObjects
{
    [Binding]
    public class SellingPage : BasePage
    {
        private IWebDriver driver;

        public SellingPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #region Locators
        public By startListingLinkBy => By.XPath("(//span[@class='tm-shell-main-nav__member-options-link--text'])[3]");

        public By generalItemLinkBy => By.XPath("(//div[@class='tm-list-vertical-picker__primary-text p-copy'])[1]");
        public By searchResultTextBy => By.XPath("//h3");

        public By dropDownItemsBy => By.CssSelector("ul>li");


        #endregion Locators
        #region Elements
        public IWebElement ListingLink => driver.FindElement(startListingLinkBy);
        public IList<IWebElement> DropdownItems => driver.FindElements(dropDownItemsBy);
        public IWebElement GeneralItemLink => driver.FindElement(generalItemLinkBy);

        public IWebElement ListAnItemHeading => driver.FindElement(By.TagName("h1"));
        #endregion Elements
    }
}
