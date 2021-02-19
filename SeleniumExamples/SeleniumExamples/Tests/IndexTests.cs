using NUnit.Framework;
using OpenQA.Selenium.Firefox;
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

            _sut.IndexPage.ClickPageFooterLink();
            _sut.IndexPage.SwitchToNextTab();
            var result = _sut.IndexPage.ReadPageURL();

            Assert.That(result, Is.EqualTo("http://elementalselenium.com/"));
        }

        [Test]
        public void GitHubImageLink_RedirectsToGitHubRepository()
        {
            _sut.NavigateToIndexPage();

            _sut.IndexPage.ClickGitHubImageLink();
            var result = _sut.IndexPage.ReadPageURL();

            Assert.That(result,
                Is.EqualTo("https://github.com/saucelabs/the-internet"));
        }

        [Test]
        public void AddRemoveElementsLink_RedirectsToAddRemovePage()
        {
            _sut.NavigateToIndexPage();

            _sut.IndexPage.ClickAddRemoveElementsLink();
            var result = _sut.IndexPage.GetPageHeaderText();
            
            Assert.That(result, Is.EqualTo("Add/Remove Elements"));
        }

        [Test]
        public void FormAuthenticationLink_RedirectsToLoginPage()
        {
            _sut.NavigateToIndexPage();

            _sut.IndexPage.ClickFormAuthenticationLink();
            var result = _sut.IndexPage.GetPageHeaderText();

            Assert.That(result, Is.EqualTo("Login Page"));
        }
    }
}
