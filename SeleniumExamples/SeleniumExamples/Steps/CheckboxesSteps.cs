using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class CheckboxesSteps
    {
        private readonly PageFactory _sut;

        public CheckboxesSteps(PageFactory sut) => _sut = sut;

        private bool _initialState;

        [Given(@"the user is on the Checkboxes page")]
        public void GivenTheUserIsOnTheCheckboxesPage()
        {
            _sut.CheckboxesPage.NavigateToPage();
        }

        [Given(@"the user clicks on a checkbox (.*)")]
        public void GivenTheUserClicksOnACheckbox(int id)
        {
            _initialState = _sut.CheckboxesPage.IsCheckboxTicked(id);
            _sut.CheckboxesPage.ClickCheckbox(id);
        }

        [Then(@"the state of the checkbox (.*) should be toggled")]
        public void ThenTheStateOfTheCheckboxShouldBeToggled(int id)
        {
            var endState = _sut.CheckboxesPage.IsCheckboxTicked(id);

            Assert.That(endState, Is.Not.EqualTo(_initialState));
        }
    }
}
