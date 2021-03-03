using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class AddRemoveElementsPage : WebPage, IPageNavigation
    {
        public AddRemoveElementsPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.AddRemoveElements);
        }

        private IWebElement ButtonAdd =>
            Driver.FindElement(By.CssSelector("button"));

        private IWebElement ButtonDelete =>
            Driver.FindElement(By.CssSelector(".added-manually"));
            
        private ReadOnlyCollection<IWebElement> ButtonsDelete =>
            Driver.FindElements(By.CssSelector(".added-manually"));

        public void ClickAddButton() => ButtonAdd.Click();

        public void ClickAnyDeleteButton() => ButtonDelete.Click();

        public int CountNumberOfDeleteButtons() => ButtonsDelete.Count;
    }
}
