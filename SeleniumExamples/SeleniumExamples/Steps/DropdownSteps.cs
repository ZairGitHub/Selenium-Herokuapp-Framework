using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class DropdownSteps
    {
        private readonly PageFactory _sut;

        public DropdownSteps(PageFactory sut) => _sut = sut;

        [Given(@"the user is on the Dropdown page")]
        public void GivenTheUserIsOnTheDropdownPage()
        {
            _sut.DropdownPage.NavigateToPage();
        }

        [When(@"the user selects the option (.*) from the dropdown list")]
        public void WhenTheUserSelectsTheOptionFromTheDropdownList(int id)
        {
            _sut.DropdownPage.ClickDropdownOption(id);
        }

        [Then(@"the dropdown list should display the following text ""(.*)""")]
        public void ThenTheDropdownListShouldDisplayTheFollowingText(string dropdownText)
        {
            var result = _sut.DropdownPage.ReadDropdownText();

            Assert.That(result, Is.EqualTo(dropdownText));
        }

        [Then(@"the dropdown list should display the selected option (.*)")]
        public void ThenTheDropdownListShouldDisplayTheSelectedOption(int id)
        {
            var result = _sut.DropdownPage.ReadDropdownText();

            Assert.That(result, Is.EqualTo("Option " + id));
        }
    }
}
