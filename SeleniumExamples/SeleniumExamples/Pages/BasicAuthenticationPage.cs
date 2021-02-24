using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class BasicAuthenticationPage : WebPage, IAlertNavigation
    {
        public BasicAuthenticationPage(IWebDriver driver) : base(driver) { }

        public void NavigateToAuthentication(string username, string password)
        {
            //NavigateToURL(ConfigReader.Index + ConfigReader.BasicAuthentication);
            NavigateToURL(
                $"http://{username}:{password}@" +
                "the-internet.herokuapp.com/basic_auth");
        }

        public string ValidUsername => "admin";

        public string ValidPassword => "admin";
    }
}
