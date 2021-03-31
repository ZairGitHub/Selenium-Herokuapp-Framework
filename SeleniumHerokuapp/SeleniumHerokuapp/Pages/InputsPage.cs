using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class InputsPage : WebPage, IPageNavigation
    {
        public InputsPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Inputs);
        }

        private IWebElement FieldInput =>
            Driver.FindElement(By.CssSelector("input"));

        public void EnterValue(int value)
        {
            FieldInput.SendKeys(value.ToString());
        }

        public void EnterValue(string value)
        {
            FieldInput.SendKeys(value);
        }

        public void IncreaseValue()
        {
            FieldInput.Click();
        }

        public void DecreaseValue()
        {
            FieldInput.Click();
        }
    }
}
