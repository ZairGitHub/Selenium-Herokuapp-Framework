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

        public void SwitchToLeftFrame()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(By.CssSelector("[name = 'frame-top']"))); //0
            Driver.SwitchTo().Frame(Driver.FindElement(By.CssSelector("[name = 'frame-left']"))); //0
        }
    }
}
