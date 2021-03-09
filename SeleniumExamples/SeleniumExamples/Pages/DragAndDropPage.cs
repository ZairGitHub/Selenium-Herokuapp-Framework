using System;
using System.IO;
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

        private IWebElement ColumnA => Driver.FindElement(By.Id("column-a"));
        
        private IWebElement ColumnB => Driver.FindElement(By.Id("column-b"));

        private IWebElement ColumnAHeader =>
            Driver.FindElement(By.CssSelector("#column-a > header"));

        private IWebElement ColumnBHeader =>
            Driver.FindElement(By.CssSelector("#column-b > header"));

        public void SwapPositions()
        {
            string jsContents = File.ReadAllText(
                AppContext.BaseDirectory + @"Helpers\simulate-drag-drop.js");
            
            ((IJavaScriptExecutor)Driver).ExecuteScript(jsContents +
                "$('#column-a').simulateDragDrop({ dropTarget: '#column-b'});");
        }
        
        public bool HaveColumnPositionsBeenSwapped()
        {
            return ColumnAHeader.Text != "A";
        }
    }
}
