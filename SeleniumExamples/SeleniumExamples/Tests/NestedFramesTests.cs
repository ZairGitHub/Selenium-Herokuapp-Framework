using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    using static NestedFramesPage;

    [TestFixture]
    public class NestedFramesTests
    {
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

        [Test]
        public void ALeft()
        {
            _sut.NestedFramesPage.NavigateToPage();

            _sut.NestedFramesPage.ResizeLeftAndMiddleFrames(10);
        }

        [Test]
        public void ARight()
        {
            _sut.NestedFramesPage.NavigateToPage();

            _sut.NestedFramesPage.ResizeMiddleAndRightFrames(10);
        }

        [TestCase(ParentFrame.Top, -50)]
        [TestCase(ParentFrame.Top, 50)]
        [TestCase(ParentFrame.Bottom, -50)]
        [TestCase(ParentFrame.Bottom, 50)]
        public void ABottom(ParentFrame frame, int offSet)
        {
            _sut.NestedFramesPage.NavigateToPage();

            var initial = _sut.NestedFramesPage.GetFramePosition(frame);
            _sut.NestedFramesPage.ResizeTopAndBottomFrames(offSet);
            var end = _sut.NestedFramesPage.GetFramePosition(frame);

            Assert.That(end, Is.EqualTo(initial + offSet));
        }
    }
}
