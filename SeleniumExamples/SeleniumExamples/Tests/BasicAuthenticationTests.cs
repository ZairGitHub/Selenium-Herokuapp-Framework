using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

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
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/basic_auth");
        }

        private IAlert AlertBasicAuthentication() => _driver.SwitchTo().Alert();
        
        private IWebElement PageBody()
        {
            return _driver.FindElement(By.CssSelector("body"));
        }

        [OneTimeSetUp]
        public void OneTimeSetUp() => _driver = new FirefoxDriver();
        
        [OneTimeTearDown]
        public void OneTimeTearDown() => _driver.Quit();

        [Test]
        public void Alert_Dismiss_RedirectsToAuthenticationError()
        {
            NavigateToAuthentication();
            AlertBasicAuthentication().Dismiss();

            var result = PageBody().Text;

            Assert.That(result, Is.EqualTo(_errorString));
        }

        [Test]
        public void Alert_AcceptOnce_CreatesNewAlert()
        {
            NavigateToAuthentication();
            AlertBasicAuthentication().Accept();

            var result = AlertBasicAuthentication();

            Assert.That(result, Is.InstanceOf<IAlert>());
        }

        [Test]
        public void Alert_AcceptTwice_RedirectsToAuthenticationError()
        {
            NavigateToAuthentication();
            AlertBasicAuthentication().Accept();
            AlertBasicAuthentication().Accept();

            var result = PageBody().Text;

            Assert.That(result, Is.EqualTo(_errorString));
        }
            
        [Ignore("To be completed")]
        [Test]
        public void InvalidCredentials()
        {
            Assert.Fail();
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
