using System;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class IFrameSteps
    {
        [Given(@"the user is on the iFrame Page")]
        public void GivenTheUserIsOnTheIFramePage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user enters the text ""(.*)"" using their keyboard")]
        public void WhenTheUserEntersTheTextUsingTheirKeyboard(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the iFrame should append the input text to its default content text")]
        public void ThenTheIFrameShouldAppendTheInputTextToItsDefaultContentText()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
