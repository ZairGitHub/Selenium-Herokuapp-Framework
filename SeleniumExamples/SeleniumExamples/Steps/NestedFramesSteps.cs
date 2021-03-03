using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    using static NestedFramesPage;

    [Binding]
    public class NestedFramesSteps
    {
        private const int _offsetValueOf50 = 50;

        private readonly PageFactory _sut;

        private int _initialSize;

        public NestedFramesSteps(PageFactory sut) => _sut = sut;

        [Given(@"the user is on the Nested Frames page")]
        public void GivenTheUserIsOnTheNestedFramesPage()
        {
            _sut.NestedFramesPage.NavigateToPage();
        }
        
        [When(@"the user switches to the left frame")]
        public void WhenTheUserSwitchesToTheLeftFrame()
        {
            _sut.NestedFramesPage.SwitchToFrame(Frame.Left);
        }

        [When(@"the user switches to the middle frame")]
        public void WhenTheUserSwitchesToTheMiddleFrame()
        {
            _sut.NestedFramesPage.SwitchToFrame(Frame.Middle);
        }

        [When(@"the user switches to the right frame")]
        public void WhenTheUserSwitchesToTheRightFrame()
        {
            _sut.NestedFramesPage.SwitchToFrame(Frame.Right);
        }

        [When(@"the user switches to the bottom frame")]
        public void WhenTheUserSwitchesToTheBottomFrame()
        {
            _sut.NestedFramesPage.SwitchToFrame(Frame.Bottom);
        }

        [When(@"the user resizes the top and bottom parent frames using their shared border")]
        public void WhenTheUserResizesTheTopAndBottomParentFramesUsingTheirSharedBorder()
        {
            _initialSize = _sut.NestedFramesPage.ReadParentFramesSize();
            _sut.NestedFramesPage.ResizeTopAndBottomFrames(_offsetValueOf50);
        }

        [When(@"the user resizes the left and middle nested frames using their shared border")]
        public void WhenTheUserResizesTheLeftAndMiddleNestedFramesUsingTheirSharedBorder()
        {
            _initialSize = _sut.NestedFramesPage.ReadNestedFramesSize();
            _sut.NestedFramesPage.ResizeLeftAndMiddleFrames(_offsetValueOf50);
        }

        [When(@"the user resizes the right and middle nested frames using their shared border")]
        public void WhenTheUserResizesTheRightAndMiddleNestedFramesUsingTheirSharedBorder()
        {
            _initialSize = _sut.NestedFramesPage.ReadNestedFramesSize();
            _sut.NestedFramesPage.ResizeRightAndMiddleFrames(_offsetValueOf50);
        }

        [Then(@"the body of the frame should display the correct text ""(.*)""")]
        public void ThenTheBodyOfTheFrameShouldDisplayTheCorrectText(string frameText)
        {
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo(frameText));
        }

        [Then(@"the sizes of the parent frames should be different to their original sizes")]
        public void ThenTheSizesOfTheFramesShouldBeDifferentToTheirOriginalSizes()
        {
            var _endSize = _sut.NestedFramesPage.ReadParentFramesSize();

            Assert.That(_endSize, Is.EqualTo(_initialSize + _offsetValueOf50));
        }

        [Then(@"the sizes of the nested frames should be different to their original sizes")]
        public void ThenTheSizesOfTheNestedFramesShouldBeDifferentToTheirOriginalSizes()
        {
            var _endSize = _sut.NestedFramesPage.ReadNestedFramesSize();

            Assert.That(_endSize, Is.EqualTo(_initialSize + _offsetValueOf50));
        }
    }
}
