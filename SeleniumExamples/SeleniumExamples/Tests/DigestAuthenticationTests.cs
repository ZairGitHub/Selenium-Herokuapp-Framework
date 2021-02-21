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
        public void CancelButton_RedirectsToEmptyPage()
        {
            CreateWebDriverAndNavigateToDigestAuthenticationPage();

            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.Empty);

            _sut.CloseDriver();
        }

        [Test]
        public void OKButton_ValidCredentials_RedirectsToDigestAuthenticationPage()
        {
            CreateWebDriverAndNavigateToDigestAuthenticationPage(
                DigestAuthenticationPage.ValidUsername,
                DigestAuthenticationPage.ValidPassword);

            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Digest Auth"));

            _sut.CloseDriver();
        }

        [Test]
        public void AuthenticatedUser_AuthenticationPersistsWithinWindow()
        {
            CreateWebDriverAndNavigateToDigestAuthenticationPage(
                DigestAuthenticationPage.ValidUsername,
                DigestAuthenticationPage.ValidPassword);

            _sut.SharedHTML.OpenNewTab();
            _sut.SharedHTML.CloseTab(0);
            _sut.SharedHTML.SwitchToTab(0);
            _sut.NavigateToDigestAuthenticationPage();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Digest Auth"));

            _sut.CloseDriver();
        }
    }
}
