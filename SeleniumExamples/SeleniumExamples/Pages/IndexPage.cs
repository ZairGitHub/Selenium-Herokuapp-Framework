using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class IndexPage
    {
        private readonly string _url = ConfigReader.Index;
        private readonly IWebDriver _driver;

        public IndexPage(IWebDriver driver) => _driver = driver;

        public string PageURL => _driver.Url;

        public IWebElement PageHeader2 => _driver.FindElement(By.TagName("h2"));

        public IWebElement PageHeader3 => _driver.FindElement(By.TagName("h3"));

        public IWebElement LinkFooter =>
            _driver.FindElement(By.LinkText("Elemental Selenium"));

        public IWebElement LinkGitHub =>
            _driver.FindElement(By.CssSelector("img"));

        public IWebElement LinkAddRemove =>
            _driver.FindElement(By.LinkText("Add/Remove Elements"));

        public IWebElement LinkFormAuthentiication =>
            _driver.FindElement(By.LinkText("Form Authentication"));

        public void NavigateToPage() => _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");

        public void SwitchToNextTab()
        {
            _driver.SwitchTo().Window(
                _driver.WindowHandles[_driver.WindowHandles.Count - 1]);
        }

        public void CloseDriver() => _driver.Quit();

        public string GetPageHeaderText()
        {
            string result;
            try
            {
                result = PageHeader2.Text;
            }
            catch (NoSuchElementException)
            {
                try
                {
                    result = PageHeader3.Text;
                }
                catch (NoSuchElementException e)
                {
                    result = e.StackTrace;
                }
            }
            return result;
        }

        public void ClickPageFooterLink() => LinkFooter.Click();

        public void ClickGitHubImageLink() => LinkGitHub.Click();

        public void ClickAddRemoveElementsLink() => LinkAddRemove.Click();

        public void ClickFormAuthenticationLink() => LinkFormAuthentiication.Click();
    }
}
