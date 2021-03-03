using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class DragDropPage : WebPage, IPageNavigation
    {
        public DragDropPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.DragAndDrop);
        }
    }
}
