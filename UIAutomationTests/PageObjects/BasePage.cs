using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationTests.PageObjects
{
    public class BasePage
    {
        private IWebDriver driver;
        private string TMSandboxURL = "https://www.tmsandbox.co.nz/";
        public BasePage(IWebDriver driver) {
            this.driver = driver;
        }
        public void NavigateToTradeMeSandboxPage()
        {
            driver.Navigate().GoToUrl(TMSandboxURL);
        }
    }

}
