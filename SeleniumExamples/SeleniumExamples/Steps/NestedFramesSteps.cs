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

        [Then(@"the body of the frame should display the correct text ""(.*)""")]
        public void ThenTheBodyOfTheFrameShouldDisplayTheCorrectText(string frameText)
        {
            var result = _sut.SharedHTML.ReadPageBodyText();

            Assert.That(result, Is.EqualTo(frameText));
        }
    }
}
