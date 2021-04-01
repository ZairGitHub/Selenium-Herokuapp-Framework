using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class CheckboxesPage : WebPage, IPageNavigation
    {
        public CheckboxesPage(IWebDriver driver) : base(driver) { }

        public enum Checkbox
        {
            Checkbox1,
            Checkbox2
        }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Checkboxes);
        }
        
        private IWebElement Checkbox1 =>
            Driver.FindElement(By.CssSelector("input:nth-child(1)"));

        private IWebElement Checkbox2 =>
            Driver.FindElement(By.CssSelector("input:nth-child(3)"));

        public bool IsCheckboxTicked(Checkbox id)
        {
            IWebElement checkbox = null;
            switch (id)
            {
                case Checkbox.Checkbox1:
                    checkbox = Checkbox1;
                    break;
                case Checkbox.Checkbox2:
                    checkbox = Checkbox2;
                    break;
            }
            return checkbox.Selected;
        }

        public void ClickCheckbox(Checkbox id)
        {
            switch (id)
            {
                case Checkbox.Checkbox1:
                    Checkbox1.Click();
                    break;
                case Checkbox.Checkbox2:
                    Checkbox2.Click();
                    break;
            }
        }
    }
}
