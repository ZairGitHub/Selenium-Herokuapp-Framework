using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
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
        public void PageFooterLink_OpensElementalSeleniumWebsiteInANewTab()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.SharedHTML.ClickPageFooterLink();
            _sut.SharedHTML.SwitchToTab(1);
            var result = _sut.Driver.Url;

            Assert.That(result, Is.EqualTo("http://elementalselenium.com/"));
        }

        [Test]
        public void GitHubImageLink_RedirectsToGitHubRepository()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.SharedHTML.ClickGitHubImageLink();
            var result = _sut.Driver.Url;

            Assert.That(result,
                Is.EqualTo("https://github.com/saucelabs/the-internet"));
        }

        [Test]
        public void AddRemoveElementsLink_RedirectsToAddRemoveElementsPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickAddRemoveElementsLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();
            
            Assert.That(result, Is.EqualTo("Add/Remove Elements"));
        }

        [Ignore("Authentication alerts cannot be interacted with in ChromeDriver")]
        [Test]
        public void BasicAuthenticationLink_OpensBasicAuthenticationPopup()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickBasicAuthenticationLink();
            var result = _sut.SharedIAlert.ReadAuthenticationPopupText();
            _sut.SharedIAlert.ClickCancelButton();

            Assert.That(result, Contains.Substring("“Restricted Area”"));
        }

        [Test]
        public void CheckboxesLink_OpensCheckboxesPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickCheckboxesLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Checkboxes"));
        }

        [Ignore("Authentication alerts cannot be interacted with in ChromeDriver")]
        [Test]
        public void DigestAuthenticationLink_OpensDigestAuthenticationPopup()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickDigestAuthenticationLink();
            var result = _sut.SharedIAlert.ReadAuthenticationPopupText();
            _sut.SharedIAlert.ClickCancelButton();

            Assert.That(result, Contains.Substring("“Protected Area”"));
        }

        [Test]
        public void DragAndDropLink_RedirectsToDragAndDropPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickDragAndDropLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Drag and Drop"));
        }

        [Test]
        public void DropdownLink_RedirectsToDropdownPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickDropdownLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Dropdown List"));
        }

        [Test]
        public void FormAuthenticationLink_RedirectsToLoginPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickFormAuthenticationLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Login Page"));
        }

        [Test]
        public void FramesLink_RedirectsToFramesPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickFramesLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Frames"));
        }

        [Test]
        public void HoversLink_RedirectsToHoversPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickHoversLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Hovers"));
        }

        [Test]
        public void JavaScriptAlertsLink_RedirectsToJavaScriptAlertsPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickJavaScriptAlertsLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("JavaScript Alerts"));
        }

        [Test]
        public void NestedFramesLink_RedirectsToNestedFramesPage()
        {
            _sut.IndexPage.NavigateToPage();

            _sut.IndexPage.ClickNestedFramesLink();
            var result = _sut.Driver.Url;

            Assert.That(result,
                Is.EqualTo(ConfigReader.Index + ConfigReader.NestedFrames));
        }
    }
}
