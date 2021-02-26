using System;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class CheckboxesSteps
    {
        [Given(@"the user is on the Checkboxes page")]
        public void GivenTheUserIsOnTheCheckboxesPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the user toggles the checkbox (.*)")]
        public void GivenTheUserTogglesTheCheckbox(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user checks the checkbox (.*) state")]
        public void WhenTheUserChecksTheCheckboxState(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the checkbox (.*) state should be toggled")]
        public void ThenTheCheckboxStateShouldBeToggled(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
