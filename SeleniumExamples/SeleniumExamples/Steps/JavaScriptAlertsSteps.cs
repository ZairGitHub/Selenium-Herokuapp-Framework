using System;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class JavaScriptAlertsSteps
    {
        [Given(@"the user is on the JavaScriptAlerts page")]
        public void GivenTheUserIsOnTheJavaScriptAlertsPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user clicks the JSAlert button")]
        public void WhenTheUserClicksTheJSAlertButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user clicks the OK button")]
        public void WhenTheUserClicksTheOKButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the page should display the result text ""(.*)"" for the interaction")]
        public void ThenThePageShouldDisplayTheResultTextForTheInteraction(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
