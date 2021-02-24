using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class MiscellaneousTests
    {
        private WebsitePOM _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void InvalidUrl_RedirectsToEmptyPageWithNotFoundError()
        {
            _sut.NavigateToInvalidPage();

            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Not Found"));
        }

        [Ignore("Alert cannot be accessed in ChromeDriver")]
        [Test]
        public void AuthenticationPopup_OKButton_CreatesNewAuthenticationPopup()
        {
            _sut.BasicAuthenticationPage.NavigateToAuthentication();

            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedIAlert.AuthenticationPopupExists();
            _sut.SharedIAlert.ClickCancelButton();

            Assert.That(result, Is.True);
        }
    }
}
