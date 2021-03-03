using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    [TestFixture]
    public class AddRemoveElementsTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);
        
        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void AddButton_CreatesADeleteButton()
        {
            _sut.AddRemoveElementsPage.NavigateToPage();

            _sut.AddRemoveElementsPage.ClickAddButton();
            _sut.AddRemoveElementsPage.ClickAddButton();
            _sut.AddRemoveElementsPage.ClickAddButton();
            var result = _sut.AddRemoveElementsPage.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void DeleteButton_RemovesADeleteButton()
        {
            _sut.AddRemoveElementsPage.NavigateToPage();

            _sut.AddRemoveElementsPage.ClickAddButton();
            _sut.AddRemoveElementsPage.ClickAddButton();
            _sut.AddRemoveElementsPage.ClickAddButton();
            _sut.AddRemoveElementsPage.ClickAnyDeleteButton();
            _sut.AddRemoveElementsPage.ClickAnyDeleteButton();
            var result = _sut.AddRemoveElementsPage.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
