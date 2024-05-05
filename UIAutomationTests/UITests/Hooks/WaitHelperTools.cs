using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace UIAutomationTests.UITests.Hooks
{
    public class WaitHelper
    {
        private WebDriverWait _waitHelper;
        private IWebDriver _driver;

        public WaitHelper(IWebDriver driver)
        {
            _waitHelper = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            _driver = driver;
        }

        public WaitHelper(IWebDriver driver, double timeSpan)
        {
            _waitHelper = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            _driver = driver;
        }
        //public static bool WaitForEleDisplayed(IWebDriver driver, By by, int timespan = 10000)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timespan));
        //    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedCondition.ElementIsVisible(by));

        //}

        //public static bool WaitForEleTxtDisplayed(IWebDriver driver, IWebElement ele, string txt, int timespan = 10000)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timespan));
        //    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedCondition.TextToBePresesntInElement(ele, txt));

        //}

        //public void WaitForElementClickable(By locator)
        //{
        //        _waitHelper.Until(SeleniumExtras.ElementToBeClickable(locator));
        //}
        //public void WaitForElementClickable(IWebElement element)
        //{
        //    //   _waitHelper.Until(SeleniumExtras.ElementToBeClickable(element));
        //}
    }
}
