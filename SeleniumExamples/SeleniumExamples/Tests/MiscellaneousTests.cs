using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class MiscellaneousTests
    {
        private WebsitePOM _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void InvalidUrl_RedirectsToEmptyPageWithNotFoundError()
        {
            _sut.NavigateToInvalidPage();

            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Not Found"));
        }

        [Test]
        public void AuthenticationPopup_OKButton_CreatesNewAuthenticationPopup()
        {
            _sut.NavigateToBasicAuthenticationPage();

            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedIAlert.AuthenticationPopupExists();
            _sut.SharedIAlert.ClickCancelButton();

            Assert.That(result, Is.True);
        }
    }
}
