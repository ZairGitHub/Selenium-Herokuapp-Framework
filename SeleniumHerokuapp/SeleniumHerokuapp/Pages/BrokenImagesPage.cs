using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class BrokenImagesPage : WebPage, IPageNavigation
    {
        public BrokenImagesPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.BrokenImages);
        }
    }
}
