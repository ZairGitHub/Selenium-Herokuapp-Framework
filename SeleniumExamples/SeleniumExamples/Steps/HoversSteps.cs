using System;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class HoversSteps
    {
        [Given(@"the user is on the Hovers page")]
        public void GivenTheUserIsOnTheHoversPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user hovers over the image (.*)")]
        public void WhenTheUserHoversOverTheImage(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the user should be able to see additional name information for the image")]
        public void ThenTheUserShouldBeAbleToSeeAdditionalNameInformationForTheImage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
