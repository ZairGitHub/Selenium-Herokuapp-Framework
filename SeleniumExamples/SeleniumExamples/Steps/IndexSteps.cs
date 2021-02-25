using NUnit.Framework;
using TechTalk.SpecFlow;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class IndexSteps
    {
        private string _result;
        private WebsitePOM _sut;

        [BeforeScenario]
        public void BeforeScenario() => _sut = new WebsitePOM(StaticDriver.Type);

        [AfterScenario]
        public void AfterScenario() => _sut.CloseDriver();

        [Given(@"the user is on the Index page")]
        public void GivenTheUserIsOnTheIndexPage() => _sut.IndexPage.NavigateToPage();
        
        [When(@"the user clicks the Add/Remove Elements link")]
        public void WhenTheUserClicksTheAddRemoveElementsLink()
        {
            _sut.IndexPage.ClickAddRemoveElementsLink();
        }

        [When(@"the user clicks the Basic Authentication Link")]
        public void WhenTheUserClicksTheBasicAuthenticationLink()
        {
            _sut.IndexPage.ClickBasicAuthenticationLink();
        }

        [When(@"the user clicks the Checkboxes link")]
        public void WhenTheUserClicksTheCheckboxesLink()
        {
            _sut.IndexPage.ClickCheckboxesLink();
        }

        [When(@"the user reads the page header text")]
        public void WhenTheUserReadsThePageHeaderText()
        {
            _result = _sut.SharedHTML.ReadPageHeaderText();
        }

        [When(@"the user reads the popup text")]
        public void WhenTheUserReadsThePopupText()
        {
            _result = _sut.SharedIAlert.ReadAuthenticationPopupText();
        }

        [Then(@"the text should inform the user that they are on the correct ""(.*)"" page")]
        public void ThenTheTextShouldInformTheUserThatTheyAreOnTheCorrectPage(string pageHeader)
        {
            Assert.That(_result, Is.EqualTo(pageHeader));
        }

        [Then(@"the text should inform the user that they are attempting to reach the Basic Authentication page")]
        public void ThenTheTextShouldInformTheUserThatTheyAreAttemptingToReachTheBasicAuthenticationPage()
        {
            Assert.That(_result, Contains.Substring("“Restricted Area”"));
        }
    }
}
