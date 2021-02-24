using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class BasicAuthenticationPage : WebPage, IAlertNavigation
    {
        private const string _validUsername = "admin";
        private const string _validPassword = "admin";

        public BasicAuthenticationPage(IWebDriver driver) : base(driver) { }

        public void NavigateToAuthentication(
            string username = null, string password = null)
        {
            //NavigateToURL(ConfigReader.Index + ConfigReader.BasicAuthentication);
            NavigateToURL(
                $"http://{username}:{password}@" +
                "the-internet.herokuapp.com/basic_auth");
        }

        public string ValidUsername => _validUsername;

        public string ValidPassword => _validPassword;
    }
}
