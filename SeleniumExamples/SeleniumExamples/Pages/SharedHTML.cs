using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class SharedHTML
    {
        private readonly IWebDriver _driver;

        public SharedHTML(IWebDriver driver) => _driver = driver;

        private IWebElement LinkFooter =>
            _driver.FindElement(By.LinkText("Elemental Selenium"));

        private IWebElement LinkGitHub =>
            _driver.FindElement(By.CssSelector("img"));

        private IWebElement PageBody => _driver.FindElement(By.CssSelector("body"));

        private IWebElement PageHeader2 => _driver.FindElement(By.CssSelector("h2"));

        private IWebElement PageHeader3 => _driver.FindElement(By.CssSelector("h3"));

        public void ClickPageFooterLink() => LinkFooter.Click();

        public void ClickGitHubImageLink() => LinkGitHub.Click();

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

        public string ReadPageBodyText() => PageBody.Text;

        public void OpenNewTab()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.open();");
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            _driver.Close();
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        }
    }
}
