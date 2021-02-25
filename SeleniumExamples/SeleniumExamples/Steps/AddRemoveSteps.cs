using System;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Features
{
    [Binding]
    public class AddRemoveSteps
    {
        [Given(@"the user is on the Add/Remove page")]
        public void GivenTheUserIsOnTheAddRemovePage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user clicks the add button")]
        public void WhenTheUserClicksTheAddButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a delete button should be created")]
        public void ThenADeleteButtonShouldBeCreated()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
