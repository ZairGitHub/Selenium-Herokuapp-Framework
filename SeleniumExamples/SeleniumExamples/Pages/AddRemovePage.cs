using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class AddRemovePage
    {
        private readonly IWebDriver _driver;

        public AddRemovePage(IWebDriver driver) => _driver = driver;

        private IWebElement ButtonAdd =>
            _driver.FindElement(By.CssSelector("button"));

        private IWebElement ButtonDelete =>
            _driver.FindElement(By.CssSelector(".added-manually"));
            
        private ReadOnlyCollection<IWebElement> ButtonsDelete =>
            _driver.FindElements(By.CssSelector(".added-manually"));

        public void ClickAddButton() => ButtonAdd.Click();

        public void ClickAnyDeleteButton() => ButtonDelete.Click();

        public int CountNumberOfDeleteButtons() => ButtonsDelete.Count;
    }
}
