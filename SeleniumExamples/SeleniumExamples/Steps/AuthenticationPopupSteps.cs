using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class AuthenticationPopupSteps
    {
        private readonly WebsitePOM _sut;

        public AuthenticationPopupSteps(WebsitePOM sut) => _sut = sut;

        [Given(@"the user is on the Basic Authentication form with no credentials")]
        public void GivenTheUserIsOnTheBasicAuthenticationFormWithNoCredentials()
        {
            _sut.BasicAuthenticationPage.NavigateToAuthentication();
        }

        [Given(@"the user is on the Basic Authentication form with valid credentials")]
        public void GivenTheUserIsOnTheBasicAuthenticationFormWithValidCredentials()
        {
            _sut.BasicAuthenticationPage.NavigatePastAuthentication();
        }

        [Given(@"the user is on the Digest Authentication form with no credentials")]
        public void GivenTheUserIsOnTheDigestAuthenticationFormWithNoCredentials()
        {
            _sut.DigestAuthenticationPage.NavigateToAuthentication();
        }

        [Given(@"the user is on the Digest Authentication form with valid credentials")]
        public void GivenTheUserIsOnTheDigestAuthenticationFormWithValidCredentials()
        {
            _sut.DigestAuthenticationPage.NavigatePastAuthentication();
        }

        [When(@"the user clicks the cancel button on the popup")]
        public void WhenTheUserClicksTheCancelButtonOnThePopup()
        {
            _sut.SharedIAlert.ClickCancelButton();
        }

        [When(@"the user opens a new tab and closes their previous tab")]
        public void WhenTheUserOpensANewTabAndClosesTheirPreviousTab()
        {
            _sut.SharedHTML.OpenNewTab();
            _sut.SharedHTML.CloseTab(0);
            _sut.SharedHTML.SwitchToTab(0);
        }

        [When(@"the user navigates to the Basic Authentication form with no credentials")]
        public void WhenTheUserNavigatesToTheBasicAuthenticationFormWithNoCredentials()
        {
            _sut.BasicAuthenticationPage.NavigateToAuthentication();
        }

        [When(@"the user navigates to the Digest Authentication form with no credentials")]
        public void WhenTheUserNavigatesToTheDigestAuthenticationFormWithNoCredentials()
        {
            _sut.DigestAuthenticationPage.NavigateToAuthentication();
        }

        [Then(@"the page header text should inform the user that their credentials could not be authenticated ""(.*)""")]
        public void ThenThePageHeaderTextShouldInformTheUserThatTheirCredentialsCouldNotBeAuthenticated(string pageHeader)
        {
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo(pageHeader));
        }

        [Then(@"the page header text should inform the user that their credentials have successfully been authenticated ""(.*)""")]
        public void ThenThePageHeaderTextShouldInformTheUserThatTheirCredentialsHaveSuccessfullyBeenAuthenticated(string pageHeader)
        {
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo(pageHeader));
        }
    }
}
