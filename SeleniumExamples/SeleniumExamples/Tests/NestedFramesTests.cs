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
        public void TopFrameNestedFramesText(NestedFrame frame, string expected)
        {
            _sut.NestedFramesPage.NavigateToPage();

            _sut.NestedFramesPage.SwitchToParentFrame(ParentFrame.Top);
            _sut.NestedFramesPage.SwitchToNestedFrame(frame);
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void LeftFrameText()
        {
            _sut.NestedFramesPage.NavigateToPage();

            _sut.NestedFramesPage.SwitchToNestedLeftFrame();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("LEFT"));
        }

        [Test]
        public void MiddleFrameText()
        {
            _sut.NestedFramesPage.NavigateToPage();

            _sut.NestedFramesPage.SwitchToNestedMiddleFrame();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("MIDDLE"));
        }

        [Test]
        public void RightFrameText()
        {
            _sut.NestedFramesPage.NavigateToPage();

            _sut.NestedFramesPage.SwitchToNestedRightFrame();
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo("RIGHT"));
        }
    }
}
