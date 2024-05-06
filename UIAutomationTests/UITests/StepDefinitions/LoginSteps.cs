using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using TSBAssessment.UITests.Helpers;
using TSBAssessment.UITests.PageObjects;
using UIAutomationTests.UITests.PageObjects;

namespace UIAutomationTests.UITests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private BrowserHelpers browserHelpers;
        public LoginSteps(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            browserHelpers = new BrowserHelpers(driver);
        }
        [Given(@"I'm on TradeMe home page")]
        public void GivenImOnTheHomePage()

        {
            loginPage.NavigateToTradeMeSandboxPage();
        }
        [Given(@"I click on the login link")]
        public void WhenIClickOnTheLoginInButton()
        {
            loginPage.LoginLink.Click();
        }

        [When(@"I enter Email and password")]
        public void WhenIEnterEmailAndPassword()
        {
            // Find and switch to the login iframe
            IWebElement iframe = driver.FindElement(By.CssSelector("iframe.tm-auth-service-login-iframe__iframe.ng-star-inserted"));
            driver.SwitchTo().Frame(iframe);

            // Fill in email and password fields
            loginPage.EmailTextbox.SendKeys("sai@gmail.com");
            loginPage.PasswordTextbox.SendKeys("1234");

            // Wait for reCAPTCHA iframe and switch to it
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.CssSelector("iframe[title='reCAPTCHA']")));

            // Click on reCAPTCHA checkbox
            loginPage.reCaptchaCheckbox.Click();


        }


        [When(@"I successfully validate the CAPTCHA")]
        public void WhenISuccessfullyValidateTheCAPTCHA()
        {
           

        }
        [When(@"click on the signin button")]
        public void WhenClickOnTheSigninButton()
        {

            //Find and wait for login button to be visible

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement loginButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SignIn")));

            // Click on login button
            loginButton.Click();
        }

        [Then(@"home page is displayed")]
        public void ThenHomePageIsDisplayed()
        {
            Assert.IsTrue(loginPage.GetPageHeading().Contains("Home page"));
        }
        [When(@"I enter invalid email and valid password")]
        public void WhenIEnterInvalidEmailAndValidPassword()
        {
            loginPage.LogIn("invalidEmail", "validPassword");
        }
        [Then(@"the system should display an error message indicating that the username is incorrect")]
        public void ThenTheSystemShouldDisplayAnErrorMessageIndicatingThatTheUsernameIsIncorrect()
        {
            Assert.IsTrue(loginPage.GetValidationErrorText().Contains("Invalid Email Id"));
        }


        [When(@"I enter email and Invalid password")]
        public void WhenIEnterEmailAndInvalidPassword()
        {
            loginPage.LogIn("validEmail", "InvalidPassword");
        }

        [Then(@"the system should display an error message indicating that the password is incorrect")]
        public void ThenTheSystemShouldDisplayAnErrorMessageIndicatingThatThePasswordIsIncorrect()
        {
            Assert.IsTrue(loginPage.GetValidationErrorText().Contains("Invalid Password"));
        }

        [When(@"I leave both email and password fields blank")]
        public void WhenILeaveBothEmailAndPasswordFieldsBlank()
        {
            loginPage.LogIn("", "");
        }

        [Then(@"the system should display an error message indicating that the both username and password are required")]
        public void ThenTheSystemShouldDisplayAnErrorMessageIndicatingThatTheBothUsernameAndPasswordAreRequired()
        {
            Assert.IsTrue(loginPage.GetFieldValidationErrorText().Contains("Field is required"));
        }

        [When(@"I click on the Forgot Password link")]
        public void WhenIClickOnTheForgotPasswordLink()
        {
            loginPage.ForgotPasswordLink.Click();
            driver.SwitchTo().Window("new window");
        }

        [Then(@"the system should be redirected to the password reset page where they can reset their password")]
        public void ThenTheSystemShouldBeRedirectedToThePasswordResetPageWhereTheyCanResetTheirPassword()
        {
            Assert.IsTrue(loginPage.GetPageHeading().Contains("Forgot your password?")); 
        }

        [Given(@"I checked the ""([^""]*)"" checkbox during login")]
        public void GivenICheckedTheCheckboxDuringLogin(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I closes and reopens the browser")]
        public void WhenIClosesAndReopensTheBrowser()
        {
            throw new PendingStepException();
        }

        [Then(@"I should be automatically logged in without having to enter credentials again")]
        public void ThenIShouldBeAutomaticallyLoggedInWithoutHavingToEnterCredentialsAgain()
        {
            throw new PendingStepException();
        }



    }
}
