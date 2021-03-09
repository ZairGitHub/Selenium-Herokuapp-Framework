using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    [TestFixture]
    public class DragAndDropTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void SwapColumnContents_SwapsTheColumnContentsOfTwoElements()
        {
            _sut.DragAndDropPage.NavigateToPage();

            _sut.DragAndDropPage.SwapColumnContents();
            var result = _sut.DragAndDropPage.HaveColumnContentsBeenSwapped();

            Assert.That(result, Is.True);
        }

        [Test]
        public void SwapColumnContents_CalledTwice_ReturnsColumnContentsToTheirOriginalElements()
        {
            _sut.DragAndDropPage.NavigateToPage();

            _sut.DragAndDropPage.SwapColumnContents();
            _sut.DragAndDropPage.SwapColumnContents();
            var result = _sut.DragAndDropPage.HaveColumnContentsBeenSwapped();

            Assert.That(result, Is.False);
        }
    }
}
