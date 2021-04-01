using NUnit.Framework;
using SeleniumHerokuapp.Pages;

namespace SeleniumHerokuapp.Tests
{
    using static NestedFramesPage;

    [TestFixture]
    public class NestedFramesTests
    {
        private const int _valueOf50 = 50;

        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [TestCase(Frame.Left, "LEFT")]
        [TestCase(Frame.Middle, "MIDDLE")]
        [TestCase(Frame.Right, "RIGHT")]
        [TestCase(Frame.Bottom, "BOTTOM")]
        public void SwitchToFrame_FrameEnum_ReturnsCorrectTextBody(
            Frame frame, string frameText)
        {
            _sut.NestedFramesPage.NavigateToPage();

            _sut.NestedFramesPage.SwitchToFrame(frame);
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo(frameText));
        }

        [TestCase(-_valueOf50)]
        [TestCase(_valueOf50)]
        public void ResizeTopAndBottomFrames_OffsetValue_ResizesTopAndBottomFrames(
            int offset)
        {
            _sut.NestedFramesPage.NavigateToPage();
            var initialSize = _sut.NestedFramesPage.ReadParentFramesSize();

            _sut.NestedFramesPage.ResizeTopAndBottomFrames(offset);
            var endSize = _sut.NestedFramesPage.ReadParentFramesSize();

            Assert.That(endSize, Is.EqualTo(initialSize + offset));
        }

        [TestCase(-_valueOf50)]
        [TestCase(_valueOf50)]
        public void ResizeLeftAndMiddleFrames_OffsetValue_ResizesLeftAndMiddleFrames(
            int offset)
        {
            _sut.NestedFramesPage.NavigateToPage();
            var initialSize = _sut.NestedFramesPage.ReadNestedFramesSize();

            _sut.NestedFramesPage.ResizeLeftAndMiddleFrames(offset);
            var endSize = _sut.NestedFramesPage.ReadNestedFramesSize();

            Assert.That(endSize, Is.EqualTo(initialSize - offset));
        }

        [TestCase(-_valueOf50)]
        [TestCase(_valueOf50)]
        public void ResizeRightAndMiddleFrames_OffsetValue_ResizesRightAndMiddleFrames(
            int offset)
        {
            _sut.NestedFramesPage.NavigateToPage();
            var initialSize = _sut.NestedFramesPage.ReadNestedFramesSize();

            _sut.NestedFramesPage.ResizeRightAndMiddleFrames(offset);
            var endSize = _sut.NestedFramesPage.ReadNestedFramesSize();

            Assert.That(endSize, Is.EqualTo(initialSize + offset));
        }
    }
}
