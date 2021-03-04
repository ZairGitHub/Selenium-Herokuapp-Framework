using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    [TestFixture]
    public class BasicAuthenticationTests
    {
        private PageFactory _sut;

        [Ignore("Authentication alerts cannot be interacted with in ChromeDriver")]
        [Test]
        public void ClickCancelButton_RedirectsToAuthenticationError()
        {
            _sut = new PageFactory(StaticDriver.Type);
            _sut.BasicAuthenticationPage.NavigateToAuthentication();

            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));

            _sut.CloseDriver();
        }

        [Test]
        public void ClickOKButton_ValidCredentials_RedirectsToBasicAuthenticationPage()
        {
            _sut = new PageFactory(StaticDriver.Type);
            _sut.BasicAuthenticationPage.NavigatePastAuthentication();

            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));

            _sut.CloseDriver();
        }

        [Test]
        public void AuthenticatedUser_CloseSessionTab_AuthenticationSessionPersistsWithinWindow()
        {
            _sut = new PageFactory(StaticDriver.Type);
            _sut.BasicAuthenticationPage.NavigatePastAuthentication();

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
