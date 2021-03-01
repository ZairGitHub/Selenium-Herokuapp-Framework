using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class NestedFramesPage : WebPage, IPageNavigation
    {
        public NestedFramesPage(IWebDriver driver) : base(driver) { }

        private IWebElement FrameTop =>
            Driver.FindElement(By.Name("frame-top"));

        private IWebElement FrameLeft =>
            Driver.FindElement(By.Name("frame-left"));

        private IWebElement FrameBottom =>
            Driver.FindElement(By.Name("frame-bottom"));

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.NestedFrames);
        }

        public void SwitchToNestedLeftFrame()
        {
            Driver.SwitchTo().Frame(FrameTop).SwitchTo().Frame(FrameLeft);
        }
    }
}
