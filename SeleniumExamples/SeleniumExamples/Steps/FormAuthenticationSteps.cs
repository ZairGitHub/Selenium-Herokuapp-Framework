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
        
        [When(@"the user clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            _sut.FormAuthenticationPage.ClickLoginButton();
        }
        
        [Then(@"an error message containing the following text ""(.*)"" should be displayed")]
        public void ThenAnErrorMessageContainingTheFollowingTextShouldBeDisplayed(string errorMessage)
        {
            var result = _sut.FormAuthenticationPage.ReadUpdateText();

            Assert.That(result, Contains.Substring(errorMessage));
        }
    }
}
