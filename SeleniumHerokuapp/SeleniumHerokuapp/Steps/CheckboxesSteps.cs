using NUnit.Framework;
using SeleniumHerokuapp.Pages;
using TechTalk.SpecFlow;

namespace SeleniumHerokuapp.Steps
{
    using static CheckboxesPage;

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
            _initialState = _sut.CheckboxesPage.IsCheckboxTicked((CheckboxID)id);
            _sut.CheckboxesPage.ClickCheckbox((CheckboxID)id);
        }

        [Then(@"the state of the checkbox (.*) should be toggled")]
        public void ThenTheStateOfTheCheckboxShouldBeToggled(int id)
        {
            var endState = _sut.CheckboxesPage.IsCheckboxTicked((CheckboxesPage.CheckboxID)id);

            Assert.That(endState, Is.Not.EqualTo(_initialState));
        }
    }
}
