using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class NestedFrames : WebPage, IPageNavigation
    {
        public NestedFrames(IWebDriver driver) : base(driver) { }

        public enum Frame
        {
            Left,
            Middle,
            Right,
            Bottom
        }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.NestedFrames);
        }

        public void SwitchToFrame(Frame name)
        {
            Driver.SwitchTo().Frame((int)name);
        }
    }
}
