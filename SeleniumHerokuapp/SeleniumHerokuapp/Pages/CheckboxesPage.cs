using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class CheckboxesPage : WebPage, IPageNavigation
    {
        public CheckboxesPage(IWebDriver driver) : base(driver) { }

        public enum CheckboxID
        {
            Checkbox1 = 1,
            Checkbox2 = 2
        }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Checkboxes);
        }
        
        private IWebElement Checkbox1 =>
            Driver.FindElement(By.CssSelector("input:nth-child(1)"));

        private IWebElement Checkbox2 =>
            Driver.FindElement(By.CssSelector("input:nth-child(3)"));

        public bool IsCheckboxTicked(CheckboxID checkboxID)
        {
            IWebElement checkbox = null;
            switch (checkboxID)
            {
                case CheckboxID.Checkbox1:
                    checkbox = Checkbox1;
                    break;
                case CheckboxID.Checkbox2:
                    checkbox = Checkbox2;
                    break;
            }
            return checkbox.Selected;
        }

        public void ClickCheckbox(CheckboxID checkboxID)
        {
            switch (checkboxID)
            {
                case CheckboxID.Checkbox1:
                    Checkbox1.Click();
                    break;
                case CheckboxID.Checkbox2:
                    Checkbox2.Click();
                    break;
            }
        }
    }
}
