using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class JavaScriptAlertsPage : WebPage, IPageNavigation
    {
        public JavaScriptAlertsPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            //NavigateToURL(ConfigReader.Index + ConfigReader.JavaScriptAlerts);
            NavigateToURL("http://the-internet.herokuapp.com/javascript_alerts");
        }

        private IWebElement ButtonJSAlert =>
            Driver.FindElement(By.CssSelector("li:nth-child(1) > button"));

        private IWebElement ButtonJSConfirm =>
            Driver.FindElement(By.CssSelector("li:nth-child(2) > button"));

        private IWebElement ButtonJSPrompt =>
            Driver.FindElement(By.CssSelector("li:nth-child(3) > button"));

        private IWebElement TextResult => Driver.FindElement(By.Id("result"));

        public void ClickJSAlertButton() => ButtonJSAlert.Click();

        public void ClickJSConfirmButton() => ButtonJSConfirm.Click();

        public void ClickJSPromptButton() => ButtonJSPrompt.Click();

        public string ReadResultText() => TextResult.Text;
    }
}
