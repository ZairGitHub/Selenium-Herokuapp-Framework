using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class AddRemoveTests
    {
        private AddRemovePage _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new AddRemovePage(new FirefoxDriver());
        
        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void AddButton_CreatesADeleteButtonForEachClick()
        {
            _sut.NavigateToPage();

            _sut.ClickAddButton();
            _sut.ClickAddButton();
            _sut.ClickAddButton();
            var result = _sut.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void DeleteButton_RemovesADeleteButtonForEachClick()
        {
            _sut.NavigateToPage();

            _sut.ClickAddButton();
            _sut.ClickAddButton();
            _sut.ClickAddButton();
            _sut.ClickAnyDeleteButton();
            _sut.ClickAnyDeleteButton();
            var result = _sut.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
