using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class BasicAuthenticationPage
    {
        private readonly IWebDriver _driver;

        public BasicAuthenticationPage(IWebDriver driver) => _driver = driver;

        public string ValidUsername => "admin";

        public string ValidPassword => "admin";

        private IAlert AlertBasicAuthentication => _driver.SwitchTo().Alert();

        public void ClickOKButton() => AlertBasicAuthentication.Accept();

        public void ClickCancelButton() => AlertBasicAuthentication.Dismiss();

        public void DeleteAllCookies() => _driver.Manage().Cookies.DeleteAllCookies();
    }
}
