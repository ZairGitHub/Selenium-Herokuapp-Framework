using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class IFrame : WebPage, IPageNavigation
    {
        public IFrame(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.IFrame);
        }
    }
}
