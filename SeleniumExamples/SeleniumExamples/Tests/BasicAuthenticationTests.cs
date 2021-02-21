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

            _sut.BasicAuthenticationPage.ClickCancelButton();
            var result = _sut.BasicAuthenticationPage.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));

            _sut.CloseDriver();
        }

        [Test]
        public void OK_CreatesNewAuthenticationWindow()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage();

            _sut.BasicAuthenticationPage.ClickOKButton();
            var result = _sut.BasicAuthenticationPage.AuthenticationWindowExists();

            Assert.That(result, Is.True);

            _sut.CloseDriver();
        }

        [Test]
        public void OK_ClickTwice_RedirectsToAuthenticationError()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage();

            _sut.BasicAuthenticationPage.ClickOKButton();
            _sut.BasicAuthenticationPage.ClickOKButton();
            var result = _sut.BasicAuthenticationPage.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));

            _sut.CloseDriver();
        }

        [Test]
        public void OK_ValidCredentials_RedirectsToBasicAuthenticationPage()
        {
            CreateWebDriverAndNavigateToBasicAuthenticationPage("admin", "admin");
            
            var result = _sut.IndexPage.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));

            _sut.CloseDriver();
        }
    }
}
