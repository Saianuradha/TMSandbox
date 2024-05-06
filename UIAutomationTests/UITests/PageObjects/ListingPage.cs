using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationTests.UITests.PageObjects;

namespace TSBAssessment.UITests.PageObjects
{
    public class ListingPage : BasePage
    {
        private IWebDriver driver;
        public ListingPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        #region Elements
        public IWebElement ListingDetaisHeading => driver.FindElement(By.XPath("//h2[text()='Listing Details']"));
        public IWebElement ItemDesc => driver.FindElement(By.XPath("//h2[text()='Item Details']/parent::div//textarea"));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@name= 'submit']"));

        public void searchForAnItem(string itemName)
        {
            ItemDesc.SendKeys(itemName);
        }

        #endregion Elements
    }
}
