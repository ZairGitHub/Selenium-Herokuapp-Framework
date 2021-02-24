using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class FormAuthenticationTests
    {
        private WebsitePOM<FirefoxDriver> _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM<FirefoxDriver>();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void LoginButton_DisplaysInvalidUsernameError()
        {
            _sut.FormAuthenticationPage.NavigateToPage();

            _sut.FormAuthenticationPage.ClickLoginButton();
            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result, Contains.Substring("Your username is invalid!"));
        }

        [Test]
        public void LoginButton_ValidUsernameAndNoPassword_DisplaysInvalidPasswordError()
        {
            _sut.FormAuthenticationPage.NavigateToPage();

            _sut.FormAuthenticationPage.EnterValidUsername();
            _sut.FormAuthenticationPage.ClickLoginButton();
            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result, Contains.Substring("Your password is invalid!"));
        }

        [Test]
        public void LoginButton_ValidUsernameAndPassword_RedirectsToSecureAreaPage()
        {
            _sut.FormAuthenticationPage.NavigateToPage();

            _sut.FormAuthenticationPage.EnterValidUsername();
            _sut.FormAuthenticationPage.EnterValidPassword();
            _sut.FormAuthenticationPage.ClickLoginButton();

            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result,
                Contains.Substring("You logged into a secure area!"));
        }

        [Test]
        public void DirectlyNavigateToSecureAreaPage_RedirectsToFormAuthenticationPageWithErrorMessage()
        {
            _sut.SecureAreaPage.NavigateToPage();

            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result,
                Contains.Substring("You must login to view the secure area!"));
        }

        [Test]
        public void LogoutButton_RemovesAuthenticationAndRedirectsToFormAuthenticationPage()
        {
            _sut.FormAuthenticationPage.NavigateToPage();
            _sut.FormAuthenticationPage.LogInAsAuthenticatedUser();

            _sut.SecureAreaPage.ClickLogoutButton();
            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result,
                Contains.Substring("You logged out of the secure area!"));
        }

        [Test]
        public void Back_LogoutButton_RestoresAuthenticationAndRedirectsUserToSecureArea()
        {
            _sut.FormAuthenticationPage.NavigateToPage();
            _sut.FormAuthenticationPage.LogInAsAuthenticatedUser();

            _sut.SecureAreaPage.ClickLogoutButton();
            _sut.Driver.Navigate().Back();

            var result = _sut.SecureAreaPage.ReadUpdateText();

            Assert.That(result,
                Contains.Substring("You logged into a secure area!"));
        }
    }
}
