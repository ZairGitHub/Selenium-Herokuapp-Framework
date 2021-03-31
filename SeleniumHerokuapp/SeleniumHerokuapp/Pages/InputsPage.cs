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

        private IWebElement Input => Driver.FindElement(By.CssSelector("input"));

        public string ReadValue() => Input.GetAttribute("value");
        
        public void EnterValue(int value) => Input.SendKeys(value.ToString());

        public void EnterValue(string value) => Input.SendKeys(value);
        
        public void IncreaseValue() => Input.SendKeys(Keys.Up);

        public void DecreaseValue() => Input.SendKeys(Keys.Down);
    }
}
