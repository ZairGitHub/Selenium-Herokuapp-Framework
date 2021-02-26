using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class CheckboxesSteps
    {
        private bool _initialState;
        private bool _endState;
        private WebsitePOM _sut;

        [BeforeScenario]
        public void BeforeScenario() => _sut = new WebsitePOM(StaticDriver.Type);

        [AfterScenario]
        public void AfterScenario() => _sut.CloseDriver();

        [Given(@"the user is on the Checkboxes page")]
        public void GivenTheUserIsOnTheCheckboxesPage()
        {
            _sut.CheckboxesPage.NavigateToPage();
        }
        
        [Given(@"the user toggles the checkbox (.*)")]
        public void GivenTheUserTogglesTheCheckbox(int id)
        {
            _initialState = _sut.CheckboxesPage.IsCheckBoxTicked(id);
            _sut.CheckboxesPage.ClickCheckBox(id);
        }
        
        [When(@"the user checks the checkbox (.*) state")]
        public void WhenTheUserChecksTheCheckboxState(int id)
        {
            _endState = _sut.CheckboxesPage.IsCheckBoxTicked(id);
        }
        
        [Then(@"the checkbox state should be toggled")]
        public void ThenTheCheckboxStateShouldBeToggled()
        {
            Assert.That(_endState, Is.Not.EqualTo(_initialState));
        }
    }
}
