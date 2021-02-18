using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class AddRemovePage
    {
        private readonly string _url = ConfigReader.BaseUrl + ConfigReader.AddRemoveElements;
        private readonly IWebDriver _driver;

        public AddRemovePage(IWebDriver driver) => _driver = driver;

        public IWebElement ButtonAdd =>
            _driver.FindElement(By.CssSelector("button"));

        public IWebElement ButtonDelete =>
            _driver.FindElement(By.CssSelector(".added-manually"));
            
        public ReadOnlyCollection<IWebElement> ButtonsDelete =>
            _driver.FindElements(By.CssSelector(".added-manually"));

        public void ClickAddButton() => ButtonAdd.Click();

        public void ClickAnyDeleteButton() => ButtonDelete.Click();

        public int CountNumberOfDeleteButtons() => ButtonsDelete.Count;
        
        public void NavigateToPage() => _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");

        public void CloseDriver() => _driver.Quit();
    }
}
