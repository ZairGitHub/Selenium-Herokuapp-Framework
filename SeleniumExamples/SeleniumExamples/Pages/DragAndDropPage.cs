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

        private IWebElement ColumnAHeader =>
            Driver.FindElement(By.CssSelector("#column-a > header"));

        private IWebElement ColumnBHeader =>
            Driver.FindElement(By.CssSelector("#column-b > header"));

        public void SwapPositions()
        {
            try
            {
                string jsContents = File.ReadAllText(
                    AppContext.BaseDirectory + @"Helpers\simulate-drag-drop.jss");

                ((IJavaScriptExecutor)Driver).ExecuteScript(jsContents +
                    "$('#column-a').simulateDragDrop({dropTarget: '#column-b'});");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Unable to complete operation. File not found.");
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public bool HaveColumnPositionsBeenSwapped()
        {
            return ColumnAHeader.Text != "A";
        }
    }
}
