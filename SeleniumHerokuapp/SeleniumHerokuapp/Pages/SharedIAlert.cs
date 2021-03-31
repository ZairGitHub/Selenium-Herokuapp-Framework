using OpenQA.Selenium;

namespace SeleniumHerokuApp.Pages
{
    public sealed class SharedIAlert : WebPage
    {
        public SharedIAlert(IWebDriver driver) : base(driver) { }

        private IAlert Alert => Driver.SwitchTo().Alert();

        public bool AuthenticationPopupExists() => Alert != null;

        public string ReadAuthenticationPopupText() => Alert.Text;

        public void ClickOKButton() => Alert.Accept();

        public void ClickCancelButton() => Alert.Dismiss();

        public void EnterInformation(string input) => Alert.SendKeys(input);
    }
}
