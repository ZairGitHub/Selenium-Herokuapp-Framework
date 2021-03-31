using System;
using TechTalk.SpecFlow;

namespace SeleniumHerokuapp.Steps
{
    [Binding]
    public class BrokenImagesSteps
    {
        [Given(@"the user is on the Broken Images page")]
        public void GivenTheUserIsOnTheBrokenImagesPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user checks if an image is broken")]
        public void WhenTheUserChecksIfAnImageIsBroken()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the condition of the image should reflect this information")]
        public void ThenTheConditionOfTheImageShouldReflectThisInformation()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
