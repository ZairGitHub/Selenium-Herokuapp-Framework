using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumHerokuapp.Pages
{
    public sealed class SharedHTML : WebPage
    {
        public SharedHTML(IWebDriver driver) : base(driver) { }

        private IWebElement LinkFooter =>
            Driver.FindElement(By.LinkText("Elemental Selenium"));

        private IWebElement LinkGitHub =>
            Driver.FindElement(By.CssSelector("img"));

        private IWebElement PageBody =>
            Driver.FindElement(By.CssSelector("body"));

        private IWebElement PageHeader1 =>
            Driver.FindElement(By.CssSelector("h1"));

        private IWebElement PageHeader2 =>
            Driver.FindElement(By.CssSelector("h2"));

        private IWebElement PageHeader3 =>
            Driver.FindElement(By.CssSelector("h3"));

        public void OpenNewTab()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");
        }

        public void SwitchToTab(int index)
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[index]);
        }

        public void CloseTab(int index)
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[index]).Close();
        }

        public string ReadPageHeaderText()
        {
            string result;
            try
            {
                result = PageHeader1.Text;
            }
            catch (NoSuchElementException)
            {
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
            }
            return result;
        }

        public string ReadPageBodyText() => PageBody.Text;

        public void ClickPageFooterLink() => LinkFooter.Click();

        public void ClickGitHubImageLink()
        {
            Point position = LinkGitHub.Location;
            new Actions(Driver)
                .MoveByOffset(position.X, position.Y).Click().Perform();
        }
    }
}
