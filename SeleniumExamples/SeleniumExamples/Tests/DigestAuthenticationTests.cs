using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class DigestAuthenticationTests
    {
        private WebsitePOM _sut;

        private void CreateWebDriverAndNavigateToDigestAuthenticationPage(
            string username = null, string password = null)
        {
            _sut = new WebsitePOM();
            _sut.NavigateToDigestAuthenticationPage(username, password);
        }

        [Test]
        public void Cancel_RedirectsToEmptyPage()
        {
            CreateWebDriverAndNavigateToDigestAuthenticationPage();

            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.Empty);

            _sut.CloseDriver();
        }

        [Test]
        public void OK_CreatesNewAuthenticationPopup()
        {
            CreateWebDriverAndNavigateToDigestAuthenticationPage();

            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedIAlert.AuthenticationPopupExists();

            Assert.That(result, Is.True);

            _sut.CloseDriver();
        }

        [Test]
        public void OK_ClickTwice_RedirectsToAuthenticationError()
        {
            CreateWebDriverAndNavigateToDigestAuthenticationPage();

            _sut.SharedIAlert.ClickOKButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));

            _sut.CloseDriver();
        }

        [Test]
        public void OK_ValidCredentials_RedirectsToBasicAuthenticationPage()
        {
            CreateWebDriverAndNavigateToDigestAuthenticationPage(
                BasicAuthenticationPage.ValidUsername,
                BasicAuthenticationPage.ValidPassword);

            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));

            _sut.CloseDriver();
        }

        [Test]
        public void AuthenticatedUser_AuthenticationPersistsWithinWindow()
        {
            CreateWebDriverAndNavigateToDigestAuthenticationPage(
                BasicAuthenticationPage.ValidUsername,
                BasicAuthenticationPage.ValidPassword);

            _sut.SharedHTML.OpenNewTab();
            _sut.SharedHTML.CloseTab(0);
            _sut.SharedHTML.SwitchToTab(0);

            _sut.NavigateToDigestAuthenticationPage();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));

            _sut.CloseDriver();
        }
    }
}
