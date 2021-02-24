﻿using System;
using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class WebsitePOM
    {
        public WebsitePOM(Type driverType, bool isHeadless = false,
            int elementWaitTime = 0, int pageWaitTime = -1)
        {
            Driver = new DriverConfig(driverType,
                isHeadless, elementWaitTime, pageWaitTime).Driver;

            SharedIAlert = new SharedIAlert(Driver);
            SharedHTML = new SharedHTML(Driver);

            IndexPage = new IndexPage(Driver);
            AddRemovePage = new AddRemovePage(Driver);
            BasicAuthenticationPage = new BasicAuthenticationPage(Driver);
            CheckboxesPage = new CheckboxesPage(Driver);
            DigestAuthenticationPage = new DigestAuthenticationPage(Driver);
            FormAuthenticationPage = new FormAuthenticationPage(Driver);
            SecureAreaPage = new SecureAreaPage(Driver);
            HoversPage = new HoversPage(Driver);
            JavaScriptAlertsPage = new JavaScriptAlertsPage(Driver);
        }

        public IWebDriver Driver { get; private set; }

        public SharedHTML SharedHTML { get; private set; }

        public SharedIAlert SharedIAlert { get; private set; }

        public IndexPage IndexPage { get; private set; }

        public AddRemovePage AddRemovePage { get; private set; }

        public BasicAuthenticationPage BasicAuthenticationPage { get; private set; }

        public CheckboxesPage CheckboxesPage { get; private set; }

        public DigestAuthenticationPage DigestAuthenticationPage { get; private set; }

        public FormAuthenticationPage FormAuthenticationPage { get; private set; }

        public SecureAreaPage SecureAreaPage { get; private set; }

        public HoversPage HoversPage { get; private set; }

        public JavaScriptAlertsPage JavaScriptAlertsPage { get; private set; }

        public void NavigateToInvalidPage()
        {
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/error");
        }

        public void CloseDriver() => Driver.Quit();
    }
}
