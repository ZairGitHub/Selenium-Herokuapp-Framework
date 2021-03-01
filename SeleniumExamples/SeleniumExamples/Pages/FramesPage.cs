using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class FramesPage : WebPage, IPageNavigation
    {
        public FramesPage(IWebDriver driver) : base(driver) { }

        private IWebElement LinkNestedFrames =>
            Driver.FindElement(By.LinkText("Nested Frames"));

        private IWebElement LinkIFrame =>
            Driver.FindElement(By.LinkText("iFrame"));

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Frames);
        }

        public void ClickNestedFramesLink() => LinkNestedFrames.Click();

        public void ClickIFrameLink() => LinkIFrame.Click();
    }
}
