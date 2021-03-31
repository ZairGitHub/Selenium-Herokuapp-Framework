using NUnit.Framework;
using SeleniumHerokuapp.Pages;
using TechTalk.SpecFlow;

namespace SeleniumHerokuapp.Steps
{
    [Binding]
    public class AddRemoveElementsSteps
    {
        private readonly PageFactory _sut;

        public AddRemoveElementsSteps(PageFactory sut) => _sut = sut;
        
        [Given(@"the user is on the Add/Remove Elements page")]
        public void GivenTheUserIsOnTheAddRemoveElementsPage()
        {
            _sut.AddRemoveElementsPage.NavigateToPage();
        }

        [When(@"the user clicks the add button three times")]
        public void WhenTheUserClicksTheAddButtonThreeTimes()
        {
            _sut.AddRemoveElementsPage.ClickAddButton();
            _sut.AddRemoveElementsPage.ClickAddButton();
            _sut.AddRemoveElementsPage.ClickAddButton();
        }

        [When(@"the user clicks any delete button two times")]
        public void WhenTheUserClicksAnyDeleteButtonTwoTimes()
        {
            _sut.AddRemoveElementsPage.ClickAnyDeleteButton();
            _sut.AddRemoveElementsPage.ClickAnyDeleteButton();
        }

        [Then(@"the number of delete buttons should be equal to (.*)")]
        public void ThenTheNumberOfDeleteButtonsShouldBeEqualTo(int numberOfDeleteButtons)
        {
            var result = _sut.AddRemoveElementsPage.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(numberOfDeleteButtons));
        }
    }
}
