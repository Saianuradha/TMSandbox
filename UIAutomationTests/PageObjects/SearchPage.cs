using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationTests.PageObjects
{
    [Binding]

    public class SearchPage : BasePage
    {
        private IWebDriver driver;
        public SearchPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #region Locators
        public By browseBy => By.XPath("//button[contains(@class,'tm-browse-dropdown__global-browse-button o-transparent-button2')]");
        public By searchBy => By.CssSelector("input.tm-refine-keywords__search-input-box.ng-untouched");
        public By searchButtonBy => By.XPath("//button[contains(@class,'tm-refine-keywords__search-form-submit-button o-button2--primary')]");
        public By searchResultTextBy => By.XPath("//h3");
      
        public By dropDownItemsBy => By.CssSelector("ul>li");


        #endregion Locators
        #region Elements
        public IWebElement BrowseDropdown => driver.FindElement(browseBy);
        public IList<IWebElement> DropdownItems => driver.FindElements(dropDownItemsBy);
        public IWebElement SearchBar => driver.FindElement(searchBy);
        public IWebElement SearchButton => driver.FindElement(searchButtonBy);
        public IWebElement ResultTxt => driver.FindElement(By.TagName("h3"));
        #endregion Elements
        public string GetText()
        {
            return ResultTxt.Text;
        }
       
    }
}
