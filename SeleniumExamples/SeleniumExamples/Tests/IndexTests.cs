using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class IndexTests
    {
        private IndexPage _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new IndexPage(new FirefoxDriver());

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void PageFooterLink_RedirectsToElementalSeleniumWebsite()
        {
            _sut.NavigateToPage();

            _sut.ClickPageFooterLink();
            var result = _sut.PageURL;

            Assert.That(result, Is.EqualTo("elementalselenium.com"));
        }

        [Test]
        public void GitHubImageLink_RedirectsToGitHubRepository()
        {
            _sut.NavigateToPage();

            _sut.ClickGitHubImageLink();
            var result = _sut.PageURL;

            Assert.That(result,
                Is.EqualTo("https://github.com/saucelabs/the-internet"));
        }

        [Test]
        public void AddRemoveElementsLink_RedirectsToAddRemovePage()
        {
            _sut.NavigateToPage();

            _sut.ClickAddRemoveElementsLink();
            var result = _sut.GetPageHeaderText();
            
            Assert.That(result, Is.EqualTo("Add/Remove Elements"));
        }
    }
}
