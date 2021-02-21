﻿using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class IndexPage
    {
        private readonly IWebDriver _driver;

        public IndexPage(IWebDriver driver) => _driver = driver;

        private IWebElement LinkAddRemove =>
            _driver.FindElement(By.LinkText("Add/Remove Elements"));

        private IWebElement LinkBasicAuthentication =>
            _driver.FindElement(By.LinkText("Basic Auth"));

        private IWebElement LinkDigestAuthentication =>
            _driver.FindElement(By.LinkText("Digest Authentication"));

        private IWebElement LinkFormAuthentiication =>
            _driver.FindElement(By.LinkText("Form Authentication"));

        public void ClickAddRemoveElementsLink() => LinkAddRemove.Click();

        public void ClickBasicAuthenticationLink()
        {
            LinkBasicAuthentication.Click();
        }

        public void ClickDigestAuthenticationLink()
        {
            LinkDigestAuthentication.Click();
        }

        public void ClickFormAuthenticationLink()
        {
            LinkFormAuthentiication.Click();
        }
    }
}
