using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class CheckboxesSteps
    {
        private readonly WebsitePOM _sut = new WebsitePOM(StaticDriver.Type);

        private bool _initialState;

        [AfterScenario]
        public void AfterScenario() => _sut.CloseDriver();

        [Given(@"the user is on the Checkboxes page")]
        public void GivenTheUserIsOnTheCheckboxesPage()
        {
            _sut.CheckboxesPage.NavigateToPage();
        }

        [Given(@"the user clicks on a checkbox (.*)")]
        public void GivenTheUserClicksOnACheckbox(int id)
        {
            _initialState = _sut.CheckboxesPage.IsCheckBoxTicked(id);
            _sut.CheckboxesPage.ClickCheckBox(id);
        }

        [Then(@"the state of the checkbox (.*) should be toggled")]
        public void ThenTheStateOfTheCheckboxShouldBeToggled(int id)
        {
            var endState = _sut.CheckboxesPage.IsCheckBoxTicked(id);

            Assert.That(endState, Is.Not.EqualTo(_initialState));
        }
    }
}
