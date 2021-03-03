using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class DragAndDropPage : WebPage, IPageNavigation
    {
        public DragAndDropPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.DragAndDrop);
        }
    }
}
