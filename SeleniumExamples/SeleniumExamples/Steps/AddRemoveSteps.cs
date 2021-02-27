using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class AddRemoveSteps
    {
        private readonly WebsitePOM _sut;

        public AddRemoveSteps(WebsitePOM sut) => _sut = sut;
        
        [Given(@"the user is on the Add/Remove page")]
        public void GivenTheUserIsOnTheAddRemovePage()
        {
            _sut.AddRemovePage.NavigateToPage();
        }

        [When(@"the user clicks the add button three times")]
        public void WhenTheUserClicksTheAddButtonThreeTimes()
        {
            _sut.AddRemovePage.ClickAddButton();
            _sut.AddRemovePage.ClickAddButton();
            _sut.AddRemovePage.ClickAddButton();
        }

        [When(@"the user clicks any delete button two times")]
        public void WhenTheUserClicksAnyDeleteButtonTwoTimes()
        {
            _sut.AddRemovePage.ClickAnyDeleteButton();
            _sut.AddRemovePage.ClickAnyDeleteButton();
        }

        [Then(@"the number of delete buttons should be equal to (.*)")]
        public void ThenTheNumberOfDeleteButtonsShouldBeEqualTo(int numberOfDeleteButtons)
        {
            var result = _sut.AddRemovePage.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(numberOfDeleteButtons));
        }
    }
}
