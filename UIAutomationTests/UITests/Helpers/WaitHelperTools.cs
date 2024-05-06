using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace TSBAssessment.UITests.Helpers
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
        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

    }
}
