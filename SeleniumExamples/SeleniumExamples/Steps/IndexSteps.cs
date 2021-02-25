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

        [Given(@"I am on the Index page")]
        public void GivenIAmOnTheIndexPage() => _sut.IndexPage.NavigateToPage();

        [When(@"I click the Add/Remove Elements link")]
        public void WhenIClickTheAddRemoveElementsLink()
        {
            _sut.IndexPage.ClickAddRemoveElementsLink();
        }

        [When(@"I read the page header text")]
        public void WhenIReadThePageHeaderText()
        {
            _result = _sut.SharedHTML.ReadPageHeaderText();
        }

        [Then(@"the text should inform me that I am on the Add/Remove Elements Page")]
        public void ThenTheTextShouldInformMeThatIAmOnTheAddRemoveElementsPage()
        {
            Assert.That(_result, Is.EqualTo("Add/Remove Elements"));
        }
    }
}
