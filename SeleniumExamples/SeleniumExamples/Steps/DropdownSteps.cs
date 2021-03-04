using System;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class DropdownSteps
    {
        [Given(@"the user is on the Dropdown page")]
        public void GivenTheUserIsOnTheDropdownPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the dropdown list should not display a selected option")]
        public void ThenTheDropdownListShouldNotDisplayASelectedOption()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
