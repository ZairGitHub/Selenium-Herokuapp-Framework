using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class NestedFrames : WebPage, IPageNavigation
    {
        public NestedFrames(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.NestedFrames);
        }
    }
}
