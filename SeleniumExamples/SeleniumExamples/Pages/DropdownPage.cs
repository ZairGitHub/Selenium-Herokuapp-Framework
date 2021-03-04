using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class DropdownPage : WebPage, IPageNavigation
    {
        public DropdownPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Dropdown);
        }

        private IWebElement DropdownOption0 =>
            Driver.FindElement(By.CssSelector("option:nth-child(1)"));

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
                if (dropdownOption.Selected == true)
                return c.Text;
            }

            string dropdownText = null;
            if (DropdownOption0.Selected)
            {
                dropdownText = DropdownOption0.Text;
            }
            else if (DropdownOption1.Selected)
            {
                dropdownText = DropdownOption1.Text;
            }
            else if (DropdownOption2.Selected)
            {
                dropdownText = DropdownOption2.Text;
            }
            return dropdownText;
        }

        public void ClickOption1() => DropdownOption1.Click();

        public void ClickOption2() => DropdownOption2.Click();
    }
}
