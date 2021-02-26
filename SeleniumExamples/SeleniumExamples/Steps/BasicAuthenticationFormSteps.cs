using System;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class BasicAuthenticationFormSteps
    {
        [Given(@"the user is on the Basic Authentication Form")]
        public void GivenTheUserIsOnTheBasicAuthenticationForm()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user clicks the cancel button")]
        public void WhenTheUserClicksTheCancelButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the page header text should inform the user that they failed to authenticate their credentials")]
        public void ThenThePageHeaderTextShouldInformTheUserThatTheyFailedToAuthenticateTheirCredentials()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
