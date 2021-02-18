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
        public void AddRemoveElementsLink_HomePage_RedirectsToAddRemovePage()
        {
            _sut.NavigateToPage();

            _sut.ClickAddRemoveElementsText();
            var result = _sut.GetPageHeaderText();
            
            Assert.That(result, Is.EqualTo("Add/Remove Elements"));
        }
    }
}
