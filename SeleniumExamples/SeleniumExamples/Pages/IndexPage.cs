using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class IndexPage : WebPage, IPageNavigation
    {
        public IndexPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            //NavigateToURL(ConfigReader.Index);
            NavigateToURL("http://the-internet.herokuapp.com/");
        }

        private IWebElement LinkAddRemove =>
            Driver.FindElement(By.LinkText("Add/Remove Elements"));

        private IWebElement LinkBasicAuthentication =>
            Driver.FindElement(By.LinkText("Basic Auth"));

        private IWebElement LinkCheckboxes =>
            Driver.FindElement(By.LinkText("Checkboxes"));

        private IWebElement LinkDigestAuthentication =>
            Driver.FindElement(By.LinkText("Digest Authentication"));

        private IWebElement LinkFormAuthentiication =>
            Driver.FindElement(By.LinkText("Form Authentication"));

        private IWebElement LinkHovers =>
            Driver.FindElement(By.LinkText("Hovers"));

        private IWebElement LinkJavaScriptAlerts =>
            Driver.FindElement(By.LinkText("JavaScript Alerts"));

        public void ClickAddRemoveElementsLink() => LinkAddRemove.Click();

        public void ClickBasicAuthenticationLink()
        {
            LinkBasicAuthentication.Click();
        }

        public void ClickCheckboxesLink() => LinkCheckboxes.Click();

        public void ClickDigestAuthenticationLink()
        {
            LinkDigestAuthentication.Click();
        }

        public void ClickFormAuthenticationLink()
        {
            LinkFormAuthentiication.Click();
        }

        public void ClickHoversLink() => LinkHovers.Click();

        public void ClickJavaScriptAlertsLink() => LinkJavaScriptAlerts.Click();
    }
}
