using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    using static NestedFramesPage;

    [TestFixture]
    public class NestedFramesTests
    {
        private const int valueOf50 = 50;

        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [TestCase(NestedFrame.Left, "LEFT")]
        [TestCase(NestedFrame.Middle, "MIDDLE")]
        [TestCase(NestedFrame.Right, "RIGHT")]
        public void TopParentFrame_NestedFramesHaveTheCorrectText(
            NestedFrame nestedFrame, string nestedFrameText)
        {
            _sut.NestedFramesPage.NavigateToPage();

            _sut.NestedFramesPage.SwitchToParentFrame(ParentFrame.Top);
            _sut.NestedFramesPage.SwitchToNestedFrame(nestedFrame);
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo(nestedFrameText));
        }

        [Test]
        public void BottomParentFrame_HasTheCorrectText()
        {
            _sut.NestedFramesPage.NavigateToPage();

            _sut.NestedFramesPage.SwitchToParentFrame(ParentFrame.Bottom);
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("BOTTOM"));
        }

        [TestCase(-valueOf50)]
        [TestCase(valueOf50)]
        public void ALeft(int offset)
        {
            _sut.NestedFramesPage.NavigateToPage();
            var initialSize = _sut.NestedFramesPage.ReadNestedFrameSize();

            _sut.NestedFramesPage.ResizeLeftAndMiddleFrames(offset);
            var endSize = _sut.NestedFramesPage.ReadNestedFrameSize();

            Assert.That(endSize, Is.EqualTo(initialSize + offset));
        }

        [TestCase(-valueOf50)]
        [TestCase(valueOf50)]
        public void ARight(int offset)
        {
            _sut.NestedFramesPage.NavigateToPage();
            var initialSize = _sut.NestedFramesPage.ReadNestedFrameSize();

            _sut.NestedFramesPage.ResizeRightAndMiddleFrames(offset);
            var endSize = _sut.NestedFramesPage.ReadNestedFrameSize();

            Assert.That(endSize, Is.EqualTo(initialSize + offset));
        }

        [TestCase(-valueOf50)]
        [TestCase(valueOf50)]
        public void ABottom(int offset)
        {
            _sut.NestedFramesPage.NavigateToPage();
            var initialSize = _sut.NestedFramesPage.ReadParentFrameSize();

            _sut.NestedFramesPage.ResizeTopAndBottomFrames(offset);
            var endSize = _sut.NestedFramesPage.ReadParentFrameSize();

            Assert.That(endSize, Is.EqualTo(initialSize + offset));
        }
    }
}
