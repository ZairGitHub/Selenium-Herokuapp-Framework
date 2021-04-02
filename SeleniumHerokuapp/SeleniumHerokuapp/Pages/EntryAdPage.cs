using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class EntryAdPage : WebPage, IPageNavigation
    {
        public EntryAdPage(IWebDriver driver) :base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.EntryAd);
        }
    }
}
