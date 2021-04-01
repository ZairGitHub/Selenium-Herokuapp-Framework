using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class KeyPressesPage : WebPage, IPageNavigation
    {
        public KeyPressesPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.KeyPresses);
        }
    }
}
