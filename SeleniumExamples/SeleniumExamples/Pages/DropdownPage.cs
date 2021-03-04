using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class DropdownPage : WebPage, IPageNavigation
    {
        private int _selectedOption = 0;

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

        public string ReadDropdownText()
        {
            string dropdownText = null;
            if (_selectedOption == 0)
            {
                dropdownText = DropdownOption0.Text;
            }
            else if (_selectedOption == 1)
            {
                dropdownText = DropdownOption1.Text;
            }
            else if (_selectedOption == 2)
            {
                dropdownText = DropdownOption2.Text;
            }
            return dropdownText;
        }

        public void ClickOption1()
        {
            _selectedOption = 1;
            DropdownOption1.Click();
        }

        public void ClickOption2()
        {
            _selectedOption = 2;
            DropdownOption2.Click();
        }
    }
}
