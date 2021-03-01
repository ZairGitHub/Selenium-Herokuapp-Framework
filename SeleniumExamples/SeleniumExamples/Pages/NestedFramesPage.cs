using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class NestedFramesPage : WebPage, IPageNavigation
    {
        public NestedFramesPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.NestedFrames);
        }

        private IWebElement FrameTop =>
            Driver.FindElement(By.Name("frame-top"));

        private IWebElement FrameLeft =>
            Driver.FindElement(By.Name("frame-left"));

        private IWebElement FrameMiddle =>
            Driver.FindElement(By.Name("frame-middle"));

        private IWebElement FrameRight =>
            Driver.FindElement(By.Name("frame-right"));

        private IWebElement FrameBottom =>
            Driver.FindElement(By.Name("frame-bottom"));

        public void SwitchToNestedLeftFrame()
        {
            Driver.SwitchTo().Frame(FrameTop).SwitchTo().Frame(FrameLeft);
        }

        public void SwitchToNestedMiddleFrame()
        {
            Driver.SwitchTo().Frame(FrameTop).SwitchTo().Frame(FrameMiddle);
        }

        public void SwitchToNestedRightFrame()
        {
            Driver.SwitchTo().Frame(FrameTop).SwitchTo().Frame(FrameRight);
        }
    }
}
