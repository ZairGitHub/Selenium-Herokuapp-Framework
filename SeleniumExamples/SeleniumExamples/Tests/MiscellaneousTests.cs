using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    public class MiscellaneousTests
    {
        private WebsitePOM _sut;

        private WebsitePOM CreateDefaultWebsitePOM() => new WebsitePOM();

        [Test]
        public void InvalidUrl_RedirectsToEmptyPageWithNotFoundError()
        {
            _sut = CreateDefaultWebsitePOM();

            _sut.NavigateToInvalidPage();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Not Found"));

            _sut.CloseDriver();
        }

        [Test]
        public void AuthenticationPopup_OKButton_CreatesNewAuthenticationPopup()
        {
            _sut = CreateDefaultWebsitePOM();

            _sut.NavigateToBasicAuthenticationPage();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.SharedIAlert.AuthenticationPopupExists();

            Assert.That(result, Is.True);

            _sut.CloseDriver();
        }
    }
}
