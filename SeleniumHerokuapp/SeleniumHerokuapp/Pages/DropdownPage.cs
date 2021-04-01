using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class DropdownPage : WebPage, IPageNavigation
    {
        public DropdownPage(IWebDriver driver) : base(driver) { }

        public enum DropdownID
        {
            Option1 = 1,
            Option2 = 2
        }

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
            string text = null;
            foreach(IWebElement dropdownOption in DropDownOptions)
            {
                if (dropdownOption.Selected)
                {
                    text = dropdownOption.Text;
                    break;
                }
            }
            return text;
        }

        public void ClickDropdownOption(DropdownID dropdownID)
        {
            switch (dropdownID)
            {
                case DropdownID.Option1:
                    DropdownOption1.Click();
                    break;
                case DropdownID.Option2:
                    DropdownOption2.Click();
                    break;
            }
        }
    }
}
