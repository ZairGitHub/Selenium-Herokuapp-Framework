using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumExamples.Pages
{
    public sealed class DragAndDropPage : WebPage, IPageNavigation
    {
        public DragAndDropPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.DragAndDrop);
        }

        private IWebElement ColumnA => Driver.FindElement(By.Id("column-a"));
        
        private IWebElement ColumnB => Driver.FindElement(By.Id("column-b"));

        private int ColumnAPosition => ColumnA.Location.X;

        private int ColumnBPosition => ColumnB.Location.X;

        public void SwapPositions()
        {
            new Actions(Driver).DragAndDrop(ColumnA, ColumnB)
                .Perform();
        }
        
        public bool HaveColumnPositionsBeenSwapped()
        {
            return ColumnAPosition > ColumnBPosition;
        }
    }
}
