using OpenQA.Selenium.Firefox;

namespace SeleniumExamples.Pages
{
    public class WebsitePOM
    {
        public WebsitePOM(
            bool isHeadless = false, int elementWaitTime = 0, int pageWaitTime = -1)
        {
            Driver = new DriverConfig(
                isHeadless, elementWaitTime, pageWaitTime).Driver;

            SharedIAlert = new SharedIAlert(Driver);
            SharedHTML = new SharedHTML(Driver);

            IndexPage = new IndexPage(Driver);
            AddRemovePage = new AddRemovePage(Driver);
            FormAuthenticationPage = new FormAuthenticationPage(Driver);
            SecureAreaPage = new SecureAreaPage(Driver);
            JavaScriptAlertsPage = new JavaScriptAlertsPage(Driver);
        }

        public FirefoxDriver Driver { get; private set; }

        public SharedHTML SharedHTML { get; private set; }

        public SharedIAlert SharedIAlert { get; private set; }

        public IndexPage IndexPage { get; private set; }

        public AddRemovePage AddRemovePage { get; private set; }

        public FormAuthenticationPage FormAuthenticationPage { get; private set; }

        public SecureAreaPage SecureAreaPage { get; private set; }

        public JavaScriptAlertsPage JavaScriptAlertsPage { get; private set; }

        public void NavigateToIndexPage()
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index);
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
        }

        public void NavigateToAddRemovePage()
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index + ConfigReader.AddRemoveElements);
            Driver.Navigate().GoToUrl(
                "http://the-internet.herokuapp.com/add_remove_elements/");
        }

        public void NavigateToBasicAuthenticationPage(
            string username = null, string password = null)
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index + ConfigReader.BasicAuthentication);
            Driver.Navigate().GoToUrl(
                $"http://{username}:{password}@the-internet.herokuapp.com/basic_auth");
        }

        public void NavigateToDigestAuthenticationPage(
            string username = null, string password = null)
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index + ConfigReader.DigestAuthentication);
            Driver.Navigate().GoToUrl(
                $"http://{username}:{password}@the-internet.herokuapp.com/digest_auth");
        }

        public void NavigateToFormAuthenticationPage()
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index + ConfigReader.FormAuthetication);
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
        }

        public void NavigateToSecureAreaPage(bool isAuthenticated)
        {
            if (isAuthenticated)
            {
                NavigateToFormAuthenticationPage();
                FormAuthenticationPage.LogInAsAuthenticatedUser();
            }
            else
            {
                //Driver.Navigate().GoToUrl(ConfigReader.Index + ConfigReader.SecureArea);
                Driver.Navigate().GoToUrl(
                    "http://the-internet.herokuapp.com/secure");
            }
        }

        public void NavigateToJavaScriptAlertsPage()
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index + ConfigReader.JavaScriptAlerts);
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/javascript_alerts");
        }

        public void CloseDriver() => Driver.Quit();
    }
}
