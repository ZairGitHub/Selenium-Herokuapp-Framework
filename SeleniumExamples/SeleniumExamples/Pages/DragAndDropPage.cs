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

        private IWebElement ColumnAHeader =>
            Driver.FindElement(By.CssSelector("#column-a > header"));

        private IWebElement ColumnBHeader =>
            Driver.FindElement(By.CssSelector("#column-b > header"));

        public void SwapPositions()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript(
                "simulateDragDrop(ColumnA, ColumnB)");
            /*
            new Actions(Driver)
                .DragAndDrop(ColumnA, ColumnB)
                .Perform();*/
        }
        
        public bool HaveColumnPositionsBeenSwapped()
        {
            return ColumnAHeader.Text != "A";
            //32 //247
        }
    }
}
