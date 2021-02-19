using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class FormAuthenticationTests
    {
        private WebsitePOM _sut;

        /*private IWebElement GetLogOutButton()
        {
            return _driver.FindElement(By.CssSelector(".icon-2x"));
        }*/

        private void NavigateToSecureArea()
        {
            _sut.NavigateToFormAuthenticationPage();
            _sut.FormAuthenticationPage.EnterValidUsername();
            _sut.FormAuthenticationPage.EnterValidPassword();
            _sut.FormAuthenticationPage.ClickLoginButton();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void Login_NoDetails_ReturnsInvalidUsernameError()
        {
            _sut.NavigateToFormAuthenticationPage();

            _sut.FormAuthenticationPage.ClickLoginButton();
            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result, Contains.Substring("Your username is invalid!"));
        }

        [Test]
        public void Login_ValidUsernameAndNoPassword_ReturnsInvalidPasswordError()
        {
            _sut.NavigateToFormAuthenticationPage();

            _sut.FormAuthenticationPage.EnterValidUsername();
            _sut.FormAuthenticationPage.ClickLoginButton();
            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result, Contains.Substring("Your password is invalid!"));
        }

        [Test]
        public void Login_ValidUsernameAndPassword_RedirectsToSecureAreaPage()
        {
            _sut.NavigateToFormAuthenticationPage();

            _sut.FormAuthenticationPage.EnterValidUsername();
            _sut.FormAuthenticationPage.EnterValidPassword();
            _sut.FormAuthenticationPage.ClickLoginButton();

            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result, Contains.Substring("You logged into a secure area!"));
        }

        [Test]
        public void DirectlyNavigateToSecureAreaPage_RedirectsToFormAuthenticationPageWithErrorMessage()
        {
            _sut.NavigateToSecureAreaPage(false);

            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result, Contains.Substring("You must login to view the secure area!"));
        }

        [Test]
        public void Logout_RemovesAuthenticationAndRedirectsToFormAuthenticationPage()
        {
            _sut.NavigateToSecureAreaPage(true);

            _sut.SecureAreaPage.ClickLogoutButton();
            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result, Contains.Substring("You logged out of the secure area!"));
        }

        [Test]
        public void Back_Logout_RestoresAuthenticationAndRedirectsUserToSecureArea()
        {
            _sut.NavigateToSecureAreaPage(true);

            _sut.SecureAreaPage.ClickLogoutButton();
            _sut.Driver.Navigate().Back();

            var result = _sut.SecureAreaPage.ReadUpdateText();

            Assert.That(result, Contains.Substring("You logged into a secure area!"));
        }
    }
}
