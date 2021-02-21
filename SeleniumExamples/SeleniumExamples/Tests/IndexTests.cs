using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class IndexTests
    {
        private WebsitePOM _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void PageFooterLink_OpensElementalSeleniumWebsiteInANewTab()
        {
            _sut.NavigateToIndexPage();

            _sut.SharedHTML.ClickPageFooterLink();
            _sut.SharedHTML.SwitchToTab(1);
            var result = _sut.Driver.Url;

            Assert.That(result, Is.EqualTo("http://elementalselenium.com/"));
        }

        [Test]
        public void GitHubImageLink_RedirectsToGitHubRepository()
        {
            _sut.NavigateToIndexPage();

            _sut.SharedHTML.ClickGitHubImageLink();
            var result = _sut.Driver.Url;

            Assert.That(result,
                Is.EqualTo("https://github.com/saucelabs/the-internet"));
        }

        [Test]
        public void AddRemoveElementsLink_RedirectsToAddRemovePage()
        {
            _sut.NavigateToIndexPage();

            _sut.IndexPage.ClickAddRemoveElementsLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();
            
            Assert.That(result, Is.EqualTo("Add/Remove Elements"));
        }

        [Test]
        public void BasicAuthenticationLink_RedirectsToBasicAuthenticationPage()
        {
            _sut.NavigateToIndexPage();

            _sut.IndexPage.ClickBasicAuthenticationLink();
            var result = _sut.SharedIAlert.ReadAuthenticationWindowText();

            Assert.That(result, Contains.Substring("“Restricted Area”"));
        }

        [Test]
        public void FormAuthenticationLink_RedirectsToLoginPage()
        {
            _sut.NavigateToIndexPage();

            _sut.IndexPage.ClickFormAuthenticationLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Login Page"));
        }
    }
}
