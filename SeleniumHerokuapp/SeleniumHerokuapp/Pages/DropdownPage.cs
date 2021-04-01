using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class DropdownPage : WebPage, IPageNavigation
    {
        public DropdownPage(IWebDriver driver) : base(driver) { }

        public enum Dropdown
        {
            Option1,
            Option2
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

        public void ClickDropdownOption(Dropdown id)
        {
            switch (id)
            {
                case Dropdown.Option1:
                    DropdownOption1.Click();
                    break;
                case Dropdown.Option2:
                    DropdownOption2.Click();
                    break;
            }
        }
    }
}
