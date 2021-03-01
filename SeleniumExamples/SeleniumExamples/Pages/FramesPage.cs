using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class FramesPage : WebPage, IPageNavigation
    {
        public FramesPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Frames);
        }
    }
}
