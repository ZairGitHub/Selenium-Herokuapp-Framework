using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples
{
    [TestFixture]
    public class FormAuthenticationTests
    {
        private const string _urlBase = "http://the-internet.herokuapp.com/";
        private const string _urlLogin = _urlBase + "login";
        private const string _validUsername = "tomsmith";
        private const string _validPassword = "SuperSecretPassword!";

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

        private void NavigateToPage(string url) => _driver.Navigate().GoToUrl(url);

        private void NavigateToSecureArea()
        {
            NavigateToPage(_urlLogin);
            GetUsernameField().SendKeys(_validUsername);
            GetPasswordField().SendKeys(_validPassword);
            GetLoginButton().Click();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp() => _driver = new FirefoxDriver();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _driver.Quit();

        [Test]
        public void FormAuthenticationLink_HomePage_RedirectsToLoginPage()
        {
            NavigateToPage(_urlBase);
            _driver.FindElement(By.LinkText("Form Authentication")).Click();
            
            var result = _driver.FindElement(By.TagName("h2")).Text;

            Assert.That(result, Is.EqualTo("Login Page"));
        }

        [Test]
        public void Login_NoDetails_ReturnsInvalidUsernameError()
        {
            NavigateToPage(_urlLogin);
            GetLoginButton().Click();

            var result = GetUpdate().Text;

            Assert.That(result, Contains.Substring("Your username is invalid!"));
        }

        [Test]
        public void Login_ValidUsernameAndNoPassword_ReturnsInvalidPasswordError()
        {
            NavigateToPage(_urlLogin);
            GetUsernameField().SendKeys(_validUsername);
            GetLoginButton().Click();

            var result = GetUpdate().Text;

            Assert.That(result, Contains.Substring("Your password is invalid!"));
        }

        [Test]
        public void Login_ValidUsernameAndPassword_RedirectsToSecureArea()
        {
            NavigateToPage(_urlLogin);
            GetUsernameField().SendKeys(_validUsername);
            GetPasswordField().SendKeys(_validPassword);
            GetLoginButton().Click();

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
