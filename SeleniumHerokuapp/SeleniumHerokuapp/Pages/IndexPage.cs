using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class IndexPage : WebPage, IPageNavigation
    {
        public IndexPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index);
        }

        private IWebElement LinkAddRemove =>
            Driver.FindElement(By.LinkText("Add/Remove Elements"));

        private IWebElement LinkBasicAuthentication =>
            Driver.FindElement(By.LinkText("Basic Auth"));

        private IWebElement LinkBrokenImages =>
            Driver.FindElement(By.LinkText("Broken Images"));

        private IWebElement LinkCheckboxes =>
            Driver.FindElement(By.LinkText("Checkboxes"));

        private IWebElement LinkDigestAuthentication =>
            Driver.FindElement(By.LinkText("Digest Authentication"));

        private IWebElement LinkDragAndDrop =>
            Driver.FindElement(By.LinkText("Drag and Drop"));

        private IWebElement LinkDropdown =>
            Driver.FindElement(By.LinkText("Dropdown"));

        private IWebElement LinkFormAuthentiication =>
            Driver.FindElement(By.LinkText("Form Authentication"));

        private IWebElement LinkFrames =>
            Driver.FindElement(By.LinkText("Frames"));

        private IWebElement LinkHovers =>
            Driver.FindElement(By.LinkText("Hovers"));

        private IWebElement LinkJavaScriptAlerts =>
            Driver.FindElement(By.LinkText("JavaScript Alerts"));

        private IWebElement LinkNestedFrames =>
            Driver.FindElement(By.LinkText("Nested Frames"));

        public void ClickAddRemoveElementsLink() => LinkAddRemove.Click();

        public void ClickBasicAuthenticationLink()
        {
            LinkBasicAuthentication.Click();
        }

        public void ClickBrokenImagesLink() => LinkBrokenImages.Click();

        public void ClickCheckboxesLink() => LinkCheckboxes.Click();

        public void ClickDigestAuthenticationLink()
        {
            LinkDigestAuthentication.Click();
        }

        public void ClickDragAndDropLink() => LinkDragAndDrop.Click();

        public void ClickDropdownLink() => LinkDropdown.Click();

        public void ClickFormAuthenticationLink()
        {
            LinkFormAuthentiication.Click();
        }

        public void ClickFramesLink() => LinkFrames.Click();

        public void ClickHoversLink() => LinkHovers.Click();

        public void ClickJavaScriptAlertsLink() => LinkJavaScriptAlerts.Click();

        public void ClickNestedFramesLink() => LinkNestedFrames.Click();
    }
}
