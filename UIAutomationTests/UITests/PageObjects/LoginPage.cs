using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UIAutomationTests.UITests.PageObjects;

namespace TSBAssessment.UITests.PageObjects
{
    [Binding]
    public class LoginPage : BasePage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }


        #region Elements
        public IWebElement LoginLink => driver.FindElement(By.XPath("(//a[@class='logged-out__log-in'])[1]"));
        public IWebElement EmailTextbox => driver.FindElement(By.XPath("//*[@id=\"Email\"]"));
        public IWebElement PasswordTextbox => driver.FindElement(By.XPath("//input[@type= 'password']"));
        public IWebElement RememberMeCheckbox => driver.FindElement(By.ClassName("form-group-checkbox-input__checkbox-text"));
        public IWebElement LogInButton => driver.FindElement(By.Id("SignIn"));
        public IWebElement PageHeadingText => driver.FindElement(By.ClassName("login-text"));
        public IWebElement ValidationError => driver.FindElement(By.ClassName("validation-summary-errors"));
        public IWebElement FieldValidationError => driver.FindElement(By.ClassName("field-validation-error"));

        public IWebElement iframe => driver.FindElement(By.CssSelector("//iframe[@class='tm-auth-service-login-iframe__iframe ng-star-inserted']"));
        #endregion Elements
        public string GetPageHeading()
        {
            return PageHeadingText.Text;
        }

        public string GetValidationErrorText()
        {
            return ValidationError.Text;
        }

        public string GetFieldValidationErrorText()
        {
            return FieldValidationError.Text;
        }
    }
}
