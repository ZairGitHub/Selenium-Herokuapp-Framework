using NUnit.Framework;
using SeleniumHerokuapp.Pages;

namespace SeleniumHerokuapp.Tests
{
    [TestFixture]
    public class IndexTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void ClickPageFooterLink_OpensElementalSeleniumWebsiteInANewTab()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.SharedHTML.ClickPageFooterLink();
            _sut.SharedHTML.SwitchToTab(1);
            var result = _sut.Driver.Url;

            Assert.That(result, Is.EqualTo("http://elementalselenium.com/"));
        }

        [Test]
        public void ClickGitHubImageLink_RedirectsToGitHubRepository()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.SharedHTML.ClickGitHubImageLink();
            var result = _sut.Driver.Url;

            Assert.That(result,
                Is.EqualTo("https://github.com/saucelabs/the-internet"));
        }

        [Test]
        public void ClickAddRemoveElementsLink_RedirectsToAddRemoveElementsPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickAddRemoveElementsLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();
            
            Assert.That(result, Is.EqualTo("Add/Remove Elements"));
        }

        [Ignore("Authentication alerts cannot be interacted with in ChromeDriver")]
        [Test]
        public void ClickBasicAuthenticationLink_OpensBasicAuthenticationPopup()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickBasicAuthenticationLink();
            var result = _sut.SharedIAlert.ReadAuthenticationPopupText();
            _sut.SharedIAlert.ClickCancelButton();

            Assert.That(result, Contains.Substring("“Restricted Area”"));
        }

        [Test]
        public void ClickBrokenImagesLink_OpensBrokenImagesPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickBrokenImagesLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Contains.Substring("Broken Images"));
        }

        [Test]
        public void ClickCheckboxesLink_OpensCheckboxesPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickCheckboxesLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Checkboxes"));
        }

        [Ignore("Authentication alerts cannot be interacted with in ChromeDriver")]
        [Test]
        public void ClickDigestAuthenticationLink_OpensDigestAuthenticationPopup()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickDigestAuthenticationLink();
            var result = _sut.SharedIAlert.ReadAuthenticationPopupText();
            _sut.SharedIAlert.ClickCancelButton();

            Assert.That(result, Contains.Substring("“Protected Area”"));
        }

        [Test]
        public void ClickDragAndDropLink_RedirectsToDragAndDropPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickDragAndDropLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Drag and Drop"));
        }

        [Test]
        public void ClickDropdownLink_RedirectsToDropdownPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickDropdownLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Dropdown List"));
        }

        [Test]
        public void ClickFormAuthenticationLink_RedirectsToLoginPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickFormAuthenticationLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Login Page"));
        }

        [Test]
        public void ClickFramesLink_RedirectsToFramesPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickFramesLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Frames"));
        }

        [Test]
        public void ClickHoversLink_RedirectsToHoversPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickHoversLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Hovers"));
        }

        [Test]
        public void ClickInputsLink_RedirectsToInputsPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickInputsLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Inputs"));
        }

        [Test]
        public void ClickJavaScriptAlertsLink_RedirectsToJavaScriptAlertsPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickJavaScriptAlertsLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("JavaScript Alerts"));
        }

        [Test]
        public void ClickKeyPressesLink_RedirectsToKeyPressesPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickKeyPressesLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Key Presses"));
        }

        [Test]
        public void ClickNestedFramesLink_RedirectsToNestedFramesPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickNestedFramesLink();
            var result = _sut.Driver.Url;

            Assert.That(result,
                Is.EqualTo(ConfigReader.Index + ConfigReader.NestedFrames));
        }
    }
}
