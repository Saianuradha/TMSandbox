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
        [When(@"I click on the Login in button")]
        public void WhenIClickOnTheLoginInButton()
        {
            loginPage.LoginLink.Click();   
        }

        [When(@"I enter Email and password")]
        public void WhenIEnterEmailAndPassword()
        {
            IWebElement iframe = driver.FindElement(By.CssSelector("iframe.tm-auth-service-login-iframe__iframe.ng-star-inserted"));
            driver.SwitchTo().Frame(iframe);
            loginPage.EmailTextbox.SendKeys("sai@gmail.com");
            loginPage.PasswordTextbox.SendKeys("1234");
            loginPage.RememberMeCheckbox.Click();
            loginPage.LogInButton.Click();    
        }

        [When(@"I successfully validate the CAPTCHA")]
        public void WhenISuccessfullyValidateTheCAPTCHA()
        {
            throw new PendingStepException();
        }

        [When(@"I click on Log in button")]
        public void WhenIClickOnLogInButton()
        {
            throw new PendingStepException();
        }

        [Then(@"home page is displayed")]
        public void ThenHomePageIsDisplayed()
        {
            throw new PendingStepException();
        }


    }
}
