using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class InputsPage : WebPage, IPageNavigation
    {
        public InputsPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Inputs);
        }
    }
}
