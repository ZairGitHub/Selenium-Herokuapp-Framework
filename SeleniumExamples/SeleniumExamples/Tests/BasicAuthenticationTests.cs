using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class BasicAuthenticationTests
    {
        private WebsitePOM _sut;

        private void CreateWebDriverAndNavigateToBasicAuthenticationPage(
            string username = null, string password = null)
        {
            _sut = new WebsitePOM();
            _sut.NavigateToBasicAuthenticationPage(username, password);
        }

        [Test]
        public void CancelButton_RedirectsToAuthenticationError()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage();

            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));

            _sut.CloseDriver();
        }

        [Test]
        public void OKButton_CreatesNewAuthenticationPopup()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage();

            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedIAlert.AuthenticationPopupExists();

            Assert.That(result, Is.True);

            _sut.CloseDriver();
        }

        [Test]
        public void OKButton_ClickTwiceWithoutModifyingCredentials_RedirectsToAuthenticationError()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage();

            _sut.SharedIAlert.ClickOKButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));

            _sut.CloseDriver();
        }

        [Test]
        public void OKButton_ValidCredentials_RedirectsToBasicAuthenticationPage()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage(
                BasicAuthenticationPage.ValidUsername,
                BasicAuthenticationPage.ValidPassword);
            
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));

            _sut.CloseDriver();
        }

        [Test]
        public void AuthenticatedUser_CloseSessionTab_AuthenticationPersistsWithinWindow()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage(
                BasicAuthenticationPage.ValidUsername,
                BasicAuthenticationPage.ValidPassword);

            _sut.SharedHTML.OpenNewTab();
            _sut.SharedHTML.CloseTab(0);
            _sut.SharedHTML.SwitchToTab(0);
            _sut.NavigateToBasicAuthenticationPage();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));

            _sut.CloseDriver();
        }
    }
}
