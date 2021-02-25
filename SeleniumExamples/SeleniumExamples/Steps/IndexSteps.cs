using NUnit.Framework;
using TechTalk.SpecFlow;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class IndexSteps
    {
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

        [Then(@"I should be redirected to the Add/Remove Elements Page")]
        public void ThenIShouldBeRedirectedToTheAddRemoveElementsPage()
        {
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Is.EqualTo("Add/Remove Elements"));
        }
    }
}
