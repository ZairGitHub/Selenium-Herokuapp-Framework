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

        [When(@"the user reads the page header text")]
        public void WhenTheUserReadsThePageHeaderText()
        {
            _result = _sut.SharedHTML.ReadPageHeaderText();
        }

        [Then(@"the text should inform the user that they are on the Add/Remove Elements Page")]
        public void ThenTheTextShouldInformTheUserThatTheyAreOnTheAddRemoveElementsPage()
        {
            Assert.That(_result, Is.EqualTo("Add/Remove Elements"));
        }
    }
}
