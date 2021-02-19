using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class FormAuthenticationTests
    {
        private FormAuthenticationPage _sut;

        private IWebDriver _driver;

        private IWebElement GetUsernameField()
        {
            return _driver.FindElement(By.Id("username"));
        }

        private IWebElement GetPasswordField()
        {
            return _driver.FindElement(By.Id("password"));
        }

        private IWebElement GetLoginButton()
        {
            return _driver.FindElement(By.CssSelector(".fa"));
        }

        private IWebElement GetLogOutButton()
        {
            return _driver.FindElement(By.CssSelector(".icon-2x"));
        }

        private IWebElement GetUpdate() => _driver.FindElement(By.Id("flash"));

        private void NavigateToSecureArea()
        {
            /*NavigateToPage(_urlLogin);
            GetUsernameField().SendKeys(_validUsername);
            GetPasswordField().SendKeys(_validPassword);
            GetLoginButton().Click();*/
        }

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new FormAuthenticationPage(new FirefoxDriver());

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void Login_NoDetails_ReturnsInvalidUsernameError()
        {
            _sut.NavigateToPage();

            _sut.ButtonLogin.Click();
            var result = _sut.UpdateText;

            Assert.That(result, Contains.Substring("Your username is invalid!"));
        }

        [Test]
        public void Login_ValidUsernameAndNoPassword_ReturnsInvalidPasswordError()
        {
            /*NavigateToPage(_urlLogin);
            GetUsernameField().SendKeys(_validUsername);
            GetLoginButton().Click();*/

            var result = GetUpdate().Text;

            Assert.That(result, Contains.Substring("Your password is invalid!"));
        }

        [Test]
        public void Login_ValidUsernameAndPassword_RedirectsToSecureArea()
        {
            /*NavigateToPage(_urlLogin);
            GetUsernameField().SendKeys(_validUsername);
            GetPasswordField().SendKeys(_validPassword);
            GetLoginButton().Click();*/

            var result = GetUpdate().Text;

            Assert.That(result, Contains.Substring("You logged into a secure area!"));
        }

        [Test]
        public void Logout_RemovesAuthenticationAndRedirectsUserAwayFromSecureArea()
        {
            NavigateToSecureArea();
            GetLogOutButton().Click();

            var result = GetUpdate().Text;

            Assert.That(result, Contains.Substring("You logged out of the secure area!"));
        }

        [Test]
        public void Back_Logout_RestoresAuthenticationAndRedirectsUserToSecureArea()
        {
            NavigateToSecureArea();
            GetLogOutButton().Click();
            _driver.Navigate().Back();

            var result = GetUpdate().Text;

            Assert.That(result, Contains.Substring("You logged into a secure area!"));
        }
    }
}
