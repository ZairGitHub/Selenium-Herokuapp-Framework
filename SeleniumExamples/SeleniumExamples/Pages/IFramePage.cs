using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class IFramePage : WebPage, IPageNavigation
    {
        public IFramePage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.IFrame);
        }
    }
}
