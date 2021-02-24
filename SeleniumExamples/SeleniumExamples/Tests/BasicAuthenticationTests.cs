using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class BasicAuthenticationTests
    {
        private WebsitePOM<FirefoxDriver> _sut;

        [Test]
        public void CancelButton_RedirectsToAuthenticationError()
        {
            _sut = new WebsitePOM<FirefoxDriver>();
            _sut.BasicAuthenticationPage.NavigateToAuthentication();

            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));

            _sut.CloseDriver();
        }

        [Test]
        public void OKButton_ClickTwiceWithoutModifyingCredentials_ProducesSameEffectAsCancelButton()
        {
            _sut = new WebsitePOM<FirefoxDriver>();
            _sut.BasicAuthenticationPage.NavigateToAuthentication();

            _sut.SharedIAlert.ClickOKButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));

            _sut.CloseDriver();
        }

        [Test]
        public void OKButton_ValidCredentials_RedirectsToBasicAuthenticationPage()
        {
            _sut = new WebsitePOM<FirefoxDriver>();
            _sut.BasicAuthenticationPage.NavigateToAuthentication(
                _sut.BasicAuthenticationPage.ValidUsername,
                _sut.BasicAuthenticationPage.ValidPassword);

            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));

            _sut.CloseDriver();
        }

        [Test]
        public void AuthenticatedUser_CloseSessionTab_AuthenticationPersistsWithinWindow()
        {
            _sut = new WebsitePOM<FirefoxDriver>();
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
