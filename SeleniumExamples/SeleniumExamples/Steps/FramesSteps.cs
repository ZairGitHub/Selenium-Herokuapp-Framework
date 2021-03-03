using System;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class FramesSteps
    {
        [Given(@"the user is on the Frames page")]
        public void GivenTheUserIsOnTheFramesPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user clicks the NestedFrames link")]
        public void WhenTheUserClicksTheNestedFramesLink()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user clicks the iFrames link")]
        public void WhenTheUserClicksTheIFramesLink()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
