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

        public double ReadNumber() => double.Parse(Input.GetAttribute("value"));
        
        public void EnterNumber(double value) => Input.SendKeys(value.ToString());
        
        public void IncrementNumber() => Input.SendKeys(Keys.Up);

        public void DecrementNumber() => Input.SendKeys(Keys.Down);
    }
}
