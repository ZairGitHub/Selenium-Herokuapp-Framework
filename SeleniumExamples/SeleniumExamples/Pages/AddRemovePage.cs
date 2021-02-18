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
            
        public ReadOnlyCollection<IWebElement> ButtonsDelete() =>
            _driver.FindElements(By.CssSelector(".added-manually"));
        
        private void NavigateToPage() => _driver.Navigate().GoToUrl(_url);
    }
}
