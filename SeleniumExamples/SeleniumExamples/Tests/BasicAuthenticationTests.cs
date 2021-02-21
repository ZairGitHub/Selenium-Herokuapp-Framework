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

        private WebsitePOM _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        private IWebDriver _driver;

        private void NavigateToAuthentication()
        {
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/basic_auth");
        }

        private IAlert AlertBasicAuthentication() => _driver.SwitchTo().Alert();
        
        [Test]
        public void Alert_Dismiss_RedirectsToAuthenticationError()
        {
            _sut.NavigateToBasicAuthenticationPage();
            _sut.BasicAuthenticationPage.ClickCancelButton();

            var result = _sut.BasicAuthenticationPage.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));
        }

        [Test]
        public void Alert_AcceptOnce_CreatesNewAlert()
        {
            _sut.NavigateToBasicAuthenticationPage();
            _sut.BasicAuthenticationPage.ClickOKButton();

            var result = _sut.BasicAuthenticationPage.AuthenticationWindowExists();

            Assert.That(result, Is.True);
        }

        [Test]
        public void Alert_AcceptTwice_RedirectsToAuthenticationError()
        {
            _sut.NavigateToBasicAuthenticationPage();
            _sut.BasicAuthenticationPage.ClickOKButton();
            _sut.BasicAuthenticationPage.ClickOKButton();

            var result = _sut.BasicAuthenticationPage.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));
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
            _sut.BasicAuthenticationPage.DeleteAllCookies();
            _sut.NavigateToBasicAuthenticationPage("admin", "admin");
            
            var result = _sut.IndexPage.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));
        }
    }
}
