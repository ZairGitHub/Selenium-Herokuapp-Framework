using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class IndexPage
    {
        private readonly IWebDriver _driver;

        public IndexPage(IWebDriver driver) => _driver = driver;

        private IAlert AlertBasicAuthentication => _driver.SwitchTo().Alert();

        private IWebElement PageHeader2 => _driver.FindElement(By.CssSelector("h2"));

        private IWebElement PageHeader3 => _driver.FindElement(By.CssSelector("h3"));

        private IWebElement LinkFooter =>
            _driver.FindElement(By.LinkText("Elemental Selenium"));

        private IWebElement LinkGitHub =>
            _driver.FindElement(By.CssSelector("img"));

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

        public string ReadPageHeaderText()
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

        public void ClickBasicAuthenticationLink() => LinkBasicAuthentication.Click();

        public string ReadBasicAuthenticationAlertText() => AlertBasicAuthentication.Text;

        public void ClickFormAuthenticationLink() => LinkFormAuthentiication.Click();
    }
}
