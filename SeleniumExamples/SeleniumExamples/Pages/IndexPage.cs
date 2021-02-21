using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class IndexPage
    {
        private readonly IWebDriver _driver;

        public IndexPage(IWebDriver driver) => _driver = driver;

        private IWebElement LinkAddRemove =>
            _driver.FindElement(By.LinkText("Add/Remove Elements"));

        private IWebElement LinkBasicAuthentication =>
            _driver.FindElement(By.LinkText("Basic Auth"));

        private IWebElement LinkFormAuthentiication =>
            _driver.FindElement(By.LinkText("Form Authentication"));

        public string ReadPageURL() => _driver.Url;

        public void SwitchToNextTab()
        {
            _driver.SwitchTo().Window(
                _driver.WindowHandles[_driver.WindowHandles.Count - 1]);
        }

        public void ClickAddRemoveElementsLink() => LinkAddRemove.Click();

        public void ClickBasicAuthenticationLink() => LinkBasicAuthentication.Click();

        public void ClickFormAuthenticationLink() => LinkFormAuthentiication.Click();
    }
}
