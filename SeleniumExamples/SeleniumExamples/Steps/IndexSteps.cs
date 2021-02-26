using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

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
        public void GivenTheUserIsOnTheIndexPage()
        {
            _sut.IndexPage.NavigateToPage();
        }

        [When(@"the user clicks the link in the footer of the page")]
        public void WhenTheUserClicksTheLinkInTheFooterOfThePage()
        {
            _sut.SharedHTML.ClickPageFooterLink();
        }

        [When(@"the user clicks the GitHub image")]
        public void WhenTheUserClicksTheGitHubImage()
        {
            _sut.SharedHTML.ClickGitHubImageLink();
        }

        [When(@"the user clicks the Add/Remove Elements link")]
        public void WhenTheUserClicksTheAddRemoveElementsLink()
        {
            _sut.IndexPage.ClickAddRemoveElementsLink();
        }

        [When(@"the user clicks the Basic Authentication link")]
        public void WhenTheUserClicksTheBasicAuthenticationLink()
        {
            _sut.IndexPage.ClickBasicAuthenticationLink();
        }

        [When(@"the user clicks the Checkboxes link")]
        public void WhenTheUserClicksTheCheckboxesLink()
        {
            _sut.IndexPage.ClickCheckboxesLink();
        }

        [When(@"the user clicks the Digest Authentication link")]
        public void WhenTheUserClicksTheDigestAuthenticationLink()
        {
            _sut.IndexPage.ClickDigestAuthenticationLink();
        }

        [When(@"the user clicks the Form Authentication link")]
        public void WhenTheUserClicksTheFormAuthenticationLink()
        {
            _sut.IndexPage.ClickFormAuthenticationLink();
        }

        [When(@"the user clicks the Hovers link")]
        public void WhenTheUserClicksTheHoversLink()
        {
            _sut.IndexPage.ClickHoversLink();
        }

        [When(@"the user clicks the JavaScript Alerts link")]
        public void WhenTheUserClicksTheJavaScriptAlertsLink()
        {
            _sut.IndexPage.ClickJavaScriptAlertsLink();
        }

        [When(@"the user switches to the newly created tab (.*)")]
        public void WhenTheUserSwitchesToTheNewlyCreatedTab(int index)
        {
            _sut.SharedHTML.SwitchToTab(index);
        }

        [When(@"the user reads the popup text")]
        public void WhenTheUserReadsThePopupText()
        {
            _result = _sut.SharedIAlert.ReadAuthenticationPopupText();
        }

        [Then(@"the page url should indicate that the user has been redirected to the correct ""(.*)"" website")]
        public void ThenThePageUrlShouldIndicateThatTheUserHasBeenRedirectedToTheCorrectWebsite(string url)
        {
            _result = _sut.Driver.Url;

            Assert.That(_result, Is.EqualTo(url));
        }

        [Then(@"the page header text should inform the user that they are on the correct ""(.*)"" page")]
        public void ThenThePageHeaderTextShouldInformTheUserThatTheyAreOnTheCorrectPage(string pageHeader)
        {
            _result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(_result, Is.EqualTo(pageHeader));
        }

        [Then(@"the text should inform the user that they are attempting to reach the correct ""(.*)"" page")]
        public void ThenTheTextShouldInformTheUserThatTheyAreAttemptingToReachTheCorrectPage(string pageAuthenticationArea)
        {
            Assert.That(_result, Contains.Substring(pageAuthenticationArea));
        }
    }
}
