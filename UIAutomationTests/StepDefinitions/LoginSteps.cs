using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationTests.PageObjects;

namespace UIAutomationTests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        public LoginSteps(IWebDriver driver)
        {
            this.driver = driver;
            this.loginPage = new LoginPage(driver);
        }
        [Given(@"I'm on TradeMe login page")]
        public void GivenImOnTheHomePage()

        {
            loginPage.NavigateToTradeMeSandboxPage();
        }

    }
}
