﻿using NUnit.Framework;
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
        public void Login_ValidUsernameAndPassword_RedirectsToSecureArea()
        {
            _sut.NavigateToFormAuthenticationPage();

            _sut.FormAuthenticationPage.EnterValidUsername();
            _sut.FormAuthenticationPage.EnterValidPassword();
            _sut.FormAuthenticationPage.ClickLoginButton();

            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result, Contains.Substring("You logged into a secure area!"));
        }

        [Ignore("different page")]
        [Test]
        public void Logout_RemovesAuthenticationAndRedirectsUserAwayFromSecureArea()
        {
            /*NavigateToSecureArea();
            GetLogOutButton().Click();

            var result = GetUpdate().Text;

            Assert.That(result, Contains.Substring("You logged out of the secure area!"));*/
        }

        [Ignore("different page")]
        [Test]
        public void Back_Logout_RestoresAuthenticationAndRedirectsUserToSecureArea()
        {
            /*NavigateToSecureArea();
            GetLogOutButton().Click();
            _driver.Navigate().Back();

            var result = GetUpdate().Text;

            Assert.That(result, Contains.Substring("You logged into a secure area!"));*/
        }
    }
}
