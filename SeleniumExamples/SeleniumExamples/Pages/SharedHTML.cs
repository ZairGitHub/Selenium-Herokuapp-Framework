using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class SharedHTML
    {
        private IWebDriver _driver;

        public SharedHTML(IWebDriver driver) => _driver = driver;
        
        private IWebElement PageHeader2 => _driver.FindElement(By.CssSelector("h2"));

        private IWebElement PageHeader3 => _driver.FindElement(By.CssSelector("h3"));

        private IWebElement PageBody => _driver.FindElement(By.CssSelector("body"));

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
    }
}
