using System;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class IndexSteps
    {
        [Given(@"I am on the Index page")]
        public void GivenIAmOnTheIndexPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click the ""(.*)"" link")]
        public void WhenIClickTheLink(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be redirected to the ""(.*)"" Page")]
        public void ThenIShouldBeRedirectedToThePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
