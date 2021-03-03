using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    [TestFixture]
    public class MiscellaneousTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void InvalidUrl_RedirectsToEmptyPageWithNotFoundError()
        {
            _sut.NavigateToInvalidPage();

            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Not Found"));
        }

        [Ignore("Authentication alerts cannot be interacted with in ChromeDriver")]
        [Test]
        public void AuthenticationPopup_OKButton_CreatesNewAuthenticationPopup()
        {
            _sut.BasicAuthenticationPage.NavigateToAuthentication();

            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedIAlert.AuthenticationPopupExists();
            _sut.SharedIAlert.ClickCancelButton();

            Assert.That(result, Is.True);
        }

        [Ignore("Only usable when the website is down")]
        [Test]
        public void WebsiteIsDown_NavigateToAnyPage_RedirectsToApplicationErrorPage()
        {
            _sut.IndexPage.NavigateToPage();

            var result = _sut.Driver.Title;

            Assert.That(result, Is.EqualTo("Application Error"));
        }
    }
}
