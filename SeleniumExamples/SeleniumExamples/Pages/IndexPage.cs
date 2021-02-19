using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class IndexPage
    {
        private readonly string _url = ConfigReader.Index;
        private readonly IWebDriver _driver;

        public IndexPage(IWebDriver driver) => _driver = driver;

        public string PageURL => _driver.Url;

        public IWebElement PageHeader => _driver.FindElement(By.TagName("h3"));

        public IWebElement LinkFooter =>
            _driver.FindElement(By.LinkText("Elemental Selenium"));

        public IWebElement LinkGitHub =>
            _driver.FindElement(By.CssSelector("img"));

        public IWebElement LinkAddRemove =>
            _driver.FindElement(By.LinkText("Add/Remove Elements"));

        public void NavigateToPage() => _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");

        public void SwitchToNextTab()
        {
            _driver.SwitchTo().Window(
                _driver.WindowHandles[_driver.WindowHandles.Count - 1]);
        }

        public void CloseDriver() => _driver.Quit();

        public string GetPageHeaderText() => PageHeader.Text;

        public void ClickPageFooterLink() => LinkFooter.Click();

        public void ClickGitHubImageLink() => LinkGitHub.Click();

        public void ClickAddRemoveElementsLink() => LinkAddRemove.Click();
    }
}
