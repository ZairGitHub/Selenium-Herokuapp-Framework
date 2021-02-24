using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class AddRemoveTests
    {
        private WebsitePOM<FirefoxDriver> _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM<FirefoxDriver>();
        
        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void AddButton_CreatesADeleteButton()
        {
            _sut.AddRemovePage.NavigateToPage();

            _sut.AddRemovePage.ClickAddButton();
            _sut.AddRemovePage.ClickAddButton();
            _sut.AddRemovePage.ClickAddButton();
            var result = _sut.AddRemovePage.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void DeleteButton_RemovesADeleteButton()
        {
            _sut.AddRemovePage.NavigateToPage();

            _sut.AddRemovePage.ClickAddButton();
            _sut.AddRemovePage.ClickAddButton();
            _sut.AddRemovePage.ClickAddButton();
            _sut.AddRemovePage.ClickAnyDeleteButton();
            _sut.AddRemovePage.ClickAnyDeleteButton();
            var result = _sut.AddRemovePage.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
