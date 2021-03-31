using NUnit.Framework;
using SeleniumHerokuapp.Pages;
using TechTalk.SpecFlow;

namespace SeleniumHerokuapp.Steps
{
    [Binding]
    public class BrokenImagesSteps
    {
        private readonly PageFactory _sut;

        private bool _actualCondition;

        public BrokenImagesSteps(PageFactory sut) => _sut = sut;

        [Given(@"the user is on the Broken Images page")]
        public void GivenTheUserIsOnTheBrokenImagesPage()
        {
            _sut.BrokenImagesPage.NavigateToPage();
        }

        [When(@"the user checks if an image (.*) is broken")]
        public void WhenTheUserChecksIfAnImageIsBroken(int id)
        {
            _actualCondition = _sut.BrokenImagesPage.IsImageBroken(id);
        }

        [Then(@"the condition (.*) of the image should reflect this information")]
        public void ThenTheConditionOfTheImageShouldReflectThisInformation(bool expectedCondition)
        {
            Assert.That(_actualCondition, Is.EqualTo(expectedCondition));
        }
    }
}
