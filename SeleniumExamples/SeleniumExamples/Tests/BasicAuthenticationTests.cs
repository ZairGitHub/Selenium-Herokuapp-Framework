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
        public void Cancel_RedirectsToAuthenticationError()
        {
            _sut.BasicAuthenticationPage.DeleteAllCookies();
            _sut.NavigateToBasicAuthenticationPage();
            _sut.BasicAuthenticationPage.ClickCancelButton();

            var result = _sut.BasicAuthenticationPage.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));
        }

        [Test]
        public void OK_CreatesNewAuthenticationWindow()
        {
            _sut.BasicAuthenticationPage.DeleteAllCookies();
            _sut.NavigateToBasicAuthenticationPage();
            _sut.BasicAuthenticationPage.ClickOKButton();

            var result = _sut.BasicAuthenticationPage.AuthenticationWindowExists();

            Assert.That(result, Is.True);
        }

        [Test]
        public void OK_ClickTwice_RedirectsToAuthenticationError()
        {
            _sut.BasicAuthenticationPage.DeleteAllCookies();
            _sut.NavigateToBasicAuthenticationPage();
            _sut.BasicAuthenticationPage.ClickOKButton();
            _sut.BasicAuthenticationPage.ClickOKButton();

            var result = _sut.BasicAuthenticationPage.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("Not authorized"));
        }

        [Test]
        public void OK_ValidCredentials_RedirectsToBasicAuthenticationPage()
        {
            _sut.BasicAuthenticationPage.DeleteAllCookies();
            _sut.NavigateToBasicAuthenticationPage("admin", "admin");
            
            var result = _sut.IndexPage.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));
        }
    }
}
