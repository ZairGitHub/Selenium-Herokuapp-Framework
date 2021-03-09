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
        public void SwapPositions_SwapsThePositionsOfTwoElements()
        {
            _sut.DragAndDropPage.NavigateToPage();

            _sut.DragAndDropPage.SwapPositions();
            var result = _sut.DragAndDropPage.HaveColumnPositionsBeenSwapped();

            Assert.That(result, Is.True);
        }
    }
}
