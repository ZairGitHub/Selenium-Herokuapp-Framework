﻿using OpenQA.Selenium.Firefox;

namespace SeleniumExamples.Pages
{
    public class WebsitePOM
    {
        public WebsitePOM(
            bool isHeadless = false, int elementWaitTime = 0, int pageWaitTime = -1)
        {
            Driver = new DriverConfig(
                isHeadless, elementWaitTime, pageWaitTime).Driver;

            IndexPage = new IndexPage(Driver);
            AddRemovePage = new AddRemovePage(Driver);
            BasicAuthenticationPage = new BasicAuthenticationPage(Driver);
            FormAuthenticationPage = new FormAuthenticationPage(Driver);
            SecureAreaPage = new SecureAreaPage(Driver);
        }

        public FirefoxDriver Driver { get; private set; }

        public IndexPage IndexPage { get; private set; }

        public AddRemovePage AddRemovePage { get; private set; }

        public BasicAuthenticationPage BasicAuthenticationPage { get; private set; }

        public FormAuthenticationPage FormAuthenticationPage { get; private set; }

        public SecureAreaPage SecureAreaPage { get; private set; }

        public void NavigateToIndexPage()
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index);
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
        }

        public void NavigateToAddRemovePage()
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index + ConfigReader.AddRemoveElements);
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
        }

        public void NavigateToBasicAuthenticationPage(string username, string password)
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index + ConfigReader.BasicAuthentication);
            Driver.Navigate().GoToUrl(
                $"http://{username}:{password}@the-internet.herokuapp.com/basic_auth");
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
                Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/secure");
            }
        }

        public void CloseDriver() => Driver.Quit();
    }
}
