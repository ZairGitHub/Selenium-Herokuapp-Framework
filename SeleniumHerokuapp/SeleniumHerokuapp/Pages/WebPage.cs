using OpenQA.Selenium;

namespace SeleniumHerokuApp.Pages
{
    public abstract class WebPage
    {
        protected IWebDriver Driver { get; }

        protected WebPage(IWebDriver driver) => Driver = driver;

        protected void NavigateToURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}
