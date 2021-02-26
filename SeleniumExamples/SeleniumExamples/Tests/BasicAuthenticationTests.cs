using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    [TestFixture]
    public class BasicAuthenticationTests
    {
        private WebsitePOM _sut;

        [Ignore("Alert cannot be accessed in ChromeDriver")]
        [Test]
        public void CancelButton_RedirectsToAuthenticationError()
        {
            _sut = new WebsitePOM(StaticDriver.Type);
            _sut.BasicAuthenticationPage.NavigateToAuthentication();

            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));

            _sut.CloseDriver();
        }

        [Test]
        public void OKButton_ValidCredentials_RedirectsToBasicAuthenticationPage()
        {
            _sut = new WebsitePOM(StaticDriver.Type);
            _sut.BasicAuthenticationPage.NavigateToAuthentication(
                _sut.BasicAuthenticationPage.ValidUsername,
                _sut.BasicAuthenticationPage.ValidPassword);

            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));

            _sut.CloseDriver();
        }

        [Test]
        public void AuthenticatedUser_CloseSessionTab_AuthenticationSessionPersistsWithinWindow()
        {
            _sut = new WebsitePOM(StaticDriver.Type);
            _sut.BasicAuthenticationPage.NavigateToAuthentication(
                _sut.BasicAuthenticationPage.ValidUsername,
                _sut.BasicAuthenticationPage.ValidPassword);

            _sut.SharedHTML.OpenNewTab();
            _sut.SharedHTML.CloseTab(0);
            _sut.SharedHTML.SwitchToTab(0);
            _sut.BasicAuthenticationPage.NavigateToAuthentication();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));

            _sut.CloseDriver();
        }
    }
}
