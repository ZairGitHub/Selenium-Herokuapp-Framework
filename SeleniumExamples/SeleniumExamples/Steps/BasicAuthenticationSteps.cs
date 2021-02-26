using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class BasicAuthenticationSteps
    {
        private WebsitePOM _sut;

        [BeforeScenario]
        public void BeforeScenario() => _sut = new WebsitePOM(StaticDriver.Type);

        [AfterScenario]
        public void AfterScenario() => _sut.CloseDriver();

        [Given(@"the user is on the Basic Authentication form with no credentials")]
        public void GivenTheUserIsOnTheBasicAuthenticationFormWithNoCredentials()
        {
            _sut.BasicAuthenticationPage.NavigateToAuthentication();
        }

        [Given(@"the user is on the Basic Authentication form with valid credentials")]
        public void GivenTheUserIsOnTheBasicAuthenticationFormWithValidCredentials()
        {
            _sut.BasicAuthenticationPage.NavigateToAuthentication(
                _sut.BasicAuthenticationPage.ValidUsername,
                _sut.BasicAuthenticationPage.ValidPassword);
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

        [Then(@"the page header text should inform the user that they successfully authenticated their credentials")]
        public void ThenThePageHeaderTextShouldInformTheUserThatTheySuccessfullyAuthenticatedTheirCredentials()
        {
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Basic Auth"));
        }
    }
}
