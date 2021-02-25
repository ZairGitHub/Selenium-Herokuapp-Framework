using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class AddRemoveSteps
    {
        private int _result;
        private WebsitePOM _sut;

        [BeforeScenario]
        public void BeforeScenario() => _sut = new WebsitePOM(StaticDriver.Type);

        [AfterScenario]
        public void AfterScenario() => _sut.CloseDriver();

        [Given(@"the user is on the Add/Remove page")]
        public void GivenTheUserIsOnTheAddRemovePage()
        {
            _sut.AddRemovePage.NavigateToPage();
        }
        
        [When(@"the user clicks the add button")]
        public void WhenTheUserClicksTheAddButton()
        {
            _sut.AddRemovePage.ClickAddButton();
        }
        
        [Then(@"a delete button should be created")]
        public void ThenADeleteButtonShouldBeCreated()
        {
            var result = _sut.AddRemovePage.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
