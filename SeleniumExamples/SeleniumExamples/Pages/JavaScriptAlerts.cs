using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class JavaScriptAlerts
    {
        private readonly IWebDriver _driver;

        public JavaScriptAlerts(IWebDriver driver) => _driver = driver;

        private IWebElement ButtonJSAlert =>
            _driver.FindElement(By.CssSelector("li:nth-child(1) > button"));

        private IWebElement ButtonJSConfirm =>
            _driver.FindElement(By.CssSelector("li:nth-child(2) > button"));

        private IWebElement ButtonJSPrompt =>
            _driver.FindElement(By.CssSelector("li:nth-child(3) > button"));

        private IWebElement TextResult => _driver.FindElement(By.Id("result"));

        public void ClickJSAlertButton() => ButtonJSAlert.Click();

        public void ClickJSConfirmButton() => ButtonJSConfirm.Click();

        public void ClickJSPromptButton() => ButtonJSPrompt.Click();

        public string ReadResultText() => TextResult.Text;
    }
}
