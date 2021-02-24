using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class DigestAuthenticationTests
    {
        private WebsitePOM _sut;

        [Test]
        public void CancelButton_RedirectsToEmptyPage()
        {
            _sut = new WebsitePOM(StaticDriver.Type);
            _sut.DigestAuthenticationPage.NavigateToAuthentication();

            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.Empty);

            _sut.CloseDriver();
        }

        [Test]
        public void OKButton_ClickTwiceWithoutModifyingCredentials_ProducesSameEffectAsCancelButton()
        {
            _sut = new WebsitePOM(StaticDriver.Type);
            _sut.DigestAuthenticationPage.NavigateToAuthentication();

            _sut.SharedIAlert.ClickOKButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.Empty);

            _sut.CloseDriver();
        }

        [Test]
        public void OKButton_ValidCredentials_RedirectsToDigestAuthenticationPage()
        {
            _sut = new WebsitePOM(StaticDriver.Type);
            _sut.DigestAuthenticationPage.NavigateToAuthentication(
                _sut.DigestAuthenticationPage.ValidUsername,
                _sut.DigestAuthenticationPage.ValidPassword);
            
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Digest Auth"));

            _sut.CloseDriver();
        }

        [Test]
        public void AuthenticatedUser_CloseSessionTab_AuthenticationPersistsWithinWindow()
        {
            _sut = new WebsitePOM(StaticDriver.Type);
            _sut.DigestAuthenticationPage.NavigateToAuthentication(
                _sut.DigestAuthenticationPage.ValidUsername,
                _sut.DigestAuthenticationPage.ValidPassword);

            _sut.SharedHTML.OpenNewTab();
            _sut.SharedHTML.CloseTab(0);
            _sut.SharedHTML.SwitchToTab(0);
            _sut.DigestAuthenticationPage.NavigateToAuthentication();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Digest Auth"));

            _sut.CloseDriver();
        }
    }
}
