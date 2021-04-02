using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class DigestAuthenticationPage : WebPage, IAlertNavigation
    {
        private const string _validUsername = "admin";
        private const string _validPassword = "admin";

        public DigestAuthenticationPage(IWebDriver driver) : base(driver) { }

        public void NavigateToAuthentication()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.DigestAuthentication);
        }
        
        public void NavigatePastAuthentication()
        {
            NavigateToURL(
                $"{ConfigReader.Protocol}{_validUsername}:{_validPassword}@" +
                ConfigReader.Base + ConfigReader.DigestAuthentication);
        }
    }
}
