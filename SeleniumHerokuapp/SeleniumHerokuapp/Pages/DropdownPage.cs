using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class DropdownPage : WebPage, IPageNavigation
    {
        public DropdownPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Dropdown);
        }

        private IWebElement DropdownOption1 =>
            Driver.FindElement(By.CssSelector("option:nth-child(2)"));

        private IWebElement DropdownOption2 =>
            Driver.FindElement(By.CssSelector("option:nth-child(3)"));

        private ReadOnlyCollection<IWebElement> DropDownOptions =>
            Driver.FindElements(By.CssSelector("option"));

        public string ReadDropdownText()
        {
            foreach(IWebElement dropdownOption in DropDownOptions)
            {
                if (dropdownOption.Selected)
                {
                    return dropdownOption.Text;
                }
            }
            return null;
        }

        public void ClickDropdownOption(int id)
        {
            if (id == 1)
            {
                DropdownOption1.Click();
            }
            else if (id == 2)
            {
                DropdownOption2.Click();
            }
        }
    }
}
