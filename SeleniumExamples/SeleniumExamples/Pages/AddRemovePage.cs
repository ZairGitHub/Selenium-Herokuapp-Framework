using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class AddRemovePage
    {
        private readonly string _url = ConfigReader.Index + ConfigReader.AddRemoveElements;
        private readonly IWebDriver _driver;

        public AddRemovePage(IWebDriver driver) => _driver = driver;

        private IWebElement ButtonAdd =>
            _driver.FindElement(By.CssSelector("button"));

        private IWebElement ButtonDelete =>
            _driver.FindElement(By.CssSelector(".added-manually"));
            
        private ReadOnlyCollection<IWebElement> ButtonsDelete =>
            _driver.FindElements(By.CssSelector(".added-manually"));

        public void NavigateToPage() => _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");

        public void CloseDriver() => _driver.Quit();

        public void ClickAddButton() => ButtonAdd.Click();

        public void ClickAnyDeleteButton() => ButtonDelete.Click();

        public int CountNumberOfDeleteButtons() => ButtonsDelete.Count;
    }
}
