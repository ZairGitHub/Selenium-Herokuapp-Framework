using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class CheckboxesSteps
    {
        private bool _initialState;
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

        [Then(@"the checkbox (.*) state should be toggled")]
        public void ThenTheCheckboxStateShouldBeToggled(int id)
        {
            var endState = _sut.CheckboxesPage.IsCheckBoxTicked(id);

            Assert.That(endState, Is.Not.EqualTo(_initialState));
        }
    }
}
