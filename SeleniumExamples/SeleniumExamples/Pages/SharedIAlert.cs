using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class SharedIAlert
    {
        private readonly IWebDriver _driver;

        public SharedIAlert(IWebDriver driver) => _driver = driver;

        private IAlert Alert => _driver.SwitchTo().Alert();

        public bool AuthenticationWindowExists() => Alert != null;

        public string ReadAuthenticationWindowText() => Alert.Text;

        public void ClickOKButton() => Alert.Accept();

        public void ClickCancelButton() => Alert.Dismiss();
    }
}
