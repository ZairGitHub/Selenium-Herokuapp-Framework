using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class BasicAuthenticationFormSteps
    {
        private WebsitePOM _sut;

        [BeforeScenario]
        public void BeforeScenario() => _sut = new WebsitePOM(StaticDriver.Type);

        [AfterScenario]
        public void AfterScenario() => _sut.CloseDriver();

        [Given(@"the user is on the Basic Authentication Form")]
        public void GivenTheUserIsOnTheBasicAuthenticationForm()
        {
            _sut.BasicAuthenticationPage.NavigateToAuthentication();
        }
        
        [When(@"the user clicks the cancel button")]
        public void WhenTheUserClicksTheCancelButton()
        {
            _sut.SharedIAlert.ClickCancelButton();
        }
        
        [Then(@"the page header text should inform the user that they failed to authenticate their credentials")]
        public void ThenThePageHeaderTextShouldInformTheUserThatTheyFailedToAuthenticateTheirCredentials()
        {
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Not authorized"));
        }
    }
}
