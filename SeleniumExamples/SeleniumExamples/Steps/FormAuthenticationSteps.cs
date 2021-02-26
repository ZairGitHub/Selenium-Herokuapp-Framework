using System;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class FormAuthenticationPageSteps
    {
        [Given(@"the user is on the Form Authentication page")]
        public void GivenTheUserIsOnTheFormAuthenticationPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"an error message containing the following text ""(.*)"" should be displayed")]
        public void ThenAnErrorMessageContainingTheFollowingTextShouldBeDisplayed(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
