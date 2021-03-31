using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class FramesPage : WebPage, IPageNavigation
    {
        public FramesPage(IWebDriver driver) : base(driver)
        {
            IFramePage = new IFramePage(driver);
            NestedFramesPage = new NestedFramesPage(driver);
        }

        public IFramePage IFramePage { get; private set; }

        public NestedFramesPage NestedFramesPage { get; private set; }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Frames);
        }

        private IWebElement LinkNestedFrames =>
            Driver.FindElement(By.LinkText("Nested Frames"));

        private IWebElement LinkIFrame =>
            Driver.FindElement(By.LinkText("iFrame"));

        public void ClickNestedFramesLink() => LinkNestedFrames.Click();

        public void ClickIFrameLink() => LinkIFrame.Click();
    }
}
