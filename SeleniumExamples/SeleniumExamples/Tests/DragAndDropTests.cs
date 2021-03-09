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
        public void SwapDraggableContents_SwapsTheDraggableContentsOfTwoElements()
        {
            _sut.DragAndDropPage.NavigateToPage();

            _sut.DragAndDropPage.SwapDraggableContents();
            var result = _sut.DragAndDropPage.HaveDraggableContentsBeenSwapped();

            Assert.That(result, Is.True);
        }

        [Test]
        public void SwapDraggableContents_CalledTwice_ReturnsDraggableContentsToTheirOriginalElements()
        {
            _sut.DragAndDropPage.NavigateToPage();

            _sut.DragAndDropPage.SwapDraggableContents();
            _sut.DragAndDropPage.SwapDraggableContents();
            var result = _sut.DragAndDropPage.HaveDraggableContentsBeenSwapped();

            Assert.That(result, Is.False);
        }
    }
}
