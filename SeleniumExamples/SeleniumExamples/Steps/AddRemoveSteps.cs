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

        [When(@"the user clicks any delete button")]
        public void WhenTheUserClicksAnyDeleteButton()
        {
            _sut.AddRemovePage.ClickAnyDeleteButton();
        }

        [When(@"the user counts the number of delete buttons")]
        public void WhenTheUserCountsTheNumberOfDeleteButtons()
        {
            _result = _sut.AddRemovePage.CountNumberOfDeleteButtons();
        }

        [Then(@"the number of delete buttons should be equal to (.*)")]
        public void ThenTheNumberOfDeleteButtonsShouldBeEqualTo(int numberOfDeleteButtons)
        {
            Assert.That(_result, Is.EqualTo(numberOfDeleteButtons));
        }
    }
}
