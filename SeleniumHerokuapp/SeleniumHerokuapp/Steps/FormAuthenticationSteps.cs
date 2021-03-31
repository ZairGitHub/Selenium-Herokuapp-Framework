using NUnit.Framework;
using SeleniumHerokuapp.Pages;
using TechTalk.SpecFlow;

namespace SeleniumHerokuapp.Steps
{
    [Binding]
    public class FormAuthenticationPageSteps
    {
        private readonly PageFactory _sut;

        public FormAuthenticationPageSteps(PageFactory sut) => _sut = sut;

        [Given(@"the user is on the Form Authentication page")]
        public void GivenTheUserIsOnTheFormAuthenticationPage()
        {
            _sut.FormAuthenticationPage.NavigateToPage();
        }

        [When(@"the user directly navigates to the Secure Area page")]
        public void WhenTheUserDirectlyNavigatesToTheSecureAreaPage()
        {
            _sut.FormAuthenticationPage.SecureAreaPage.NavigateToPage();
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
            _sut.FormAuthenticationPage.SecureAreaPage.ClickLogoutButton();
        }

        [When(@"the user uses the back button of the browser")]
        public void WhenTheUserUsesTheBackButtonOfTheBrowser()
        {
            _sut.Driver.Navigate().Back();
        }

        [Then(@"a help message containing the following text ""(.*)"" should be displayed")]
        public void ThenAHelpMessageContainingTheFollowingTextShouldBeDisplayed(string helpMessage)
        {
            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result, Contains.Substring(helpMessage));
        }
    }
}
