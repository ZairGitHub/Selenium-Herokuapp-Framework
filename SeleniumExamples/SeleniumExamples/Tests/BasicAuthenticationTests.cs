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
        public void Cancel_RedirectsToAuthenticationError()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage();

            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));

            _sut.CloseDriver();
        }

        [Test]
        public void OK_CreatesNewAuthenticationWindow()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage();

            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedIAlert.AuthenticationWindowExists();

            Assert.That(result, Is.True);

            _sut.CloseDriver();
        }

        [Test]
        public void OK_ClickTwice_RedirectsToAuthenticationError()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage();

            _sut.SharedIAlert.ClickOKButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));

            _sut.CloseDriver();
        }

        [Test]
        public void OK_ValidCredentials_RedirectsToBasicAuthenticationPage()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage(
                BasicAuthenticationPage.ValidUsername,
                BasicAuthenticationPage.ValidPassword);
            
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));

            _sut.CloseDriver();
        }
    }
}
