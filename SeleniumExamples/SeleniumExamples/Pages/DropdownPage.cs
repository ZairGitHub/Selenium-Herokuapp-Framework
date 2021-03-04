using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class DropdownPage : WebPage, IPageNavigation
    {
        public DropdownPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Dropdown);
        }
    }
}
