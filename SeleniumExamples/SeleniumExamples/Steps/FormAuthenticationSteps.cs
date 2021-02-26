using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class FormAuthenticationPageSteps
    {
        private WebsitePOM _sut;

        [BeforeScenario]
        public void BeforeScenario() => _sut = new WebsitePOM(StaticDriver.Type);

        [AfterScenario]
        public void AfterScenario() => _sut.CloseDriver();

        [Given(@"the user is on the Form Authentication page")]
        public void GivenTheUserIsOnTheFormAuthenticationPage()
        {
            _sut.FormAuthenticationPage.NavigateToPage();
        }

        [When(@"the user directly navigates to the Secure Area page")]
        public void WhenTheUserDirectlyNavigatesToTheSecureAreaPage()
        {
            _sut.SecureAreaPage.NavigateToPage();
        }

        [When(@"the user enters a valid username")]
        public void WhenTheUserEntersAValidUsername()
        {
            _sut.FormAuthenticationPage.EnterValidUsername();
        }

        [When(@"the user enters a valid password")]
        public void WhenTheUserEntersAValidPassword()
        {
            _sut.FormAuthenticationPage.EnterValidPassword();
        }

        [When(@"the user clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            _sut.FormAuthenticationPage.ClickLoginButton();
        }

        [When(@"the user is logged in")]
        public void WhenTheUserIsLoggedIn()
        {
            _sut.FormAuthenticationPage.LogInAsAuthenticatedUser();
        }

        [When(@"the user clicks the logout button")]
        public void WhenTheUserClicksTheLogoutButton()
        {
            _sut.SecureAreaPage.ClickLogoutButton();
        }

        [Then(@"a help message containing the following text ""(.*)"" should be displayed")]
        public void ThenAHelpMessageContainingTheFollowingTextShouldBeDisplayed(string helpMessage)
        {
            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result, Contains.Substring(helpMessage));
        }
    }
}
