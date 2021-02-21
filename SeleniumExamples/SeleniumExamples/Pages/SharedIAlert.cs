using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class SharedIAlert
    {
        private readonly IWebDriver _driver;

        public SharedIAlert(IWebDriver driver) => _driver = driver;

        private IAlert Alert => _driver.SwitchTo().Alert();

        public bool AuthenticationPopupExists() => Alert != null;

        public string ReadAuthenticationPopupText() => Alert.Text;

        public void ClickOKButton() => Alert.Accept();

        public void ClickCancelButton() => Alert.Dismiss();

        public void EnterInformation(string input) => Alert.SendKeys(input);
    }
}
