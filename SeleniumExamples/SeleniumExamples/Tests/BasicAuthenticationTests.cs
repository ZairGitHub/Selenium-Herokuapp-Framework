using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples
{
    [TestFixture]
    public class BasicAuthenticationTests
    {
        private const string _errorString = "Not authorized";
        private const string _validAuth = "admin";

        private IWebDriver _driver;

        private void NavigateToAuthentication()
        {
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            _driver.FindElement(By.LinkText("Basic Auth")).Click();
        }

        private IAlert GetAlert() => _driver.SwitchTo().Alert();
        
        private IWebElement GetErrorBody()
        {
            return _driver.FindElement(By.TagName("body"));
        }

        [OneTimeSetUp]
        public void OneTimeSetUp() => _driver = new FirefoxDriver();
        
        [OneTimeTearDown]
        public void OneTimeTearDown() => _driver.Quit();

        [Test]
        public void Alert_HasCorrectMessage()
        {
            NavigateToAuthentication();
            var result = GetAlert().Text;

            Assert.That(result, Is.EqualTo(
                "http://the-internet.herokuapp.com " +
                "is requesting your username and password. " +
                "The site says: “Restricted Area”"));
        }

        [Test]
        public void Alert_Dismiss_RedirectsToAuthenticationError()
        {
            NavigateToAuthentication();
            GetAlert().Dismiss();

            var result = GetErrorBody().Text;

            Assert.That(result, Is.EqualTo(_errorString));
        }

        [Test]
        public void Alert_AcceptOnce_CreatesNewAlert()
        {
            NavigateToAuthentication();
            GetAlert().Accept();

            var result = GetAlert();

            Assert.That(result, Is.InstanceOf<IAlert>());
        }

        [Test]
        public void Alert_AcceptTwice_RedirectsToAuthenticationError()
        {
            NavigateToAuthentication();
            GetAlert().Accept();
            GetAlert().Accept();

            var result = GetErrorBody().Text;

            Assert.That(result, Is.EqualTo(_errorString));
        }

        [Test]
        public void Alert_IncorrectDetails_Error()
        {
            NavigateToAuthentication();

            /*_chromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            _chromeDriver.FindElement(By.LinkText("Basic Auth")).Click();
            var alert = _chromeDriver.SwitchTo().Alert();*/

            var alert = GetAlert();
            alert.SetAuthenticationCredentials(_validAuth, _validAuth);
            alert.SendKeys(_validAuth + Keys.Tab + _validAuth);

            alert.Accept();
            alert.Accept();

            var result = _driver.FindElement(By.TagName("body")).Text;

            Assert.That(result, Is.EqualTo("Not authorized"));
        }

        [Test]
        public void Authenticate()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(
                "http://admin:admin@the-internet.herokuapp.com/basic_auth");

            var result = _driver.FindElement(By.CssSelector("h3")).Text;

            Assert.That(result, Is.EqualTo("Basic Auth"));
        }
    }
}
