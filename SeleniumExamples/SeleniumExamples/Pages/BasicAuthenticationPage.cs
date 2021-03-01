using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class BasicAuthenticationPage : WebPage, IAlertNavigation, IPageNavigation
    {
        private const string _validUsername = "admin";
        private const string _validPassword = "admin";

        public BasicAuthenticationPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
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
