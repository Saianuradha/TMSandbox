using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSBAssessment.UITests.Helpers
{
    public class BrowserHelpers
    {
        private IWebDriver driver; // Corrected driver object type

        public BrowserHelpers(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ScrollDownInIFrame(IWebElement iframe, int pixelsToScroll)
        {
            // Switch to the iframe
            //driver.SwitchTo().Frame(iframe);

            // Scroll down inside the iframe
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].contentWindow.scrollBy(0, {pixelsToScroll});", iframe);

            // Switch back to the default content
            driver.SwitchTo().DefaultContent();
        }

        public void ScrollToElementInIFrame(IWebElement iframe, IWebElement element)
        {
            // Switch to the iframe
            driver.SwitchTo().Frame(iframe);

            // Scroll to the element inside the iframe
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            // Switch back to the default content
            driver.SwitchTo().DefaultContent();
        }
    }
}
