using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class IndexPage
    {
        private readonly string _url = ConfigReader.Index;
        private readonly IWebDriver _driver;

        public IndexPage(IWebDriver driver) => _driver = driver;

        public IWebElement HeaderPage => _driver.FindElement(By.TagName("h3"));

        public IWebElement TextAddRemove =>
            _driver.FindElement(By.LinkText("Add/Remove Elements"));

        public string GetPageHeaderText() => HeaderPage.Text;

        public void ClickAddRemoveElementsText() => TextAddRemove.Click();

        public void NavigateToPage() => _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");

        public void CloseDriver() => _driver.Quit();
    }
}
