using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    using static NestedFramesPage;

    [Binding]
    public class NestedFramesSteps
    {
        private readonly PageFactory _sut;

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

        [Then(@"the body of the frame should display the correct text ""(.*)""")]
        public void ThenTheBodyOfTheFrameShouldDisplayTheCorrectText(string frameText)
        {
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo(frameText));
        }
    }
}
