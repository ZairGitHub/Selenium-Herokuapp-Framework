using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class NestedFramesSteps
    {
        private readonly PageFactory _sut;

        public NestedFramesSteps(PageFactory sut) => _sut = sut;

        [Given(@"the user is on the Nested Frames page")]
        public void GivenTheUserIsOnTheNestedFramesPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user switches to the frame Frame\.Left")]
        public void WhenTheUserSwitchesToTheFrameFrame_Left()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the body of the frame should display the correct text LEFT")]
        public void ThenTheBodyOfTheFrameShouldDisplayTheCorrectTextLEFT()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
