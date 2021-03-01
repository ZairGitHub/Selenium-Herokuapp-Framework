using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class BasicAuthenticationPage : WebPage, IAlertNavigation
    {
        private const string _validUsername = "admin";
        private const string _validPassword = "admin";

        public BasicAuthenticationPage(IWebDriver driver) : base(driver) { }

        public void NavigateToAuthentication()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.BasicAuthentication);
        }

        public void NavigatePastAuthentication()
        {    
            NavigateToURL($"http://{_validUsername}:{_validPassword}@" +
                ConfigReader.Base + ConfigReader.BasicAuthentication);
        }
    }
}
