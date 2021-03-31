using NUnit.Framework;
using SeleniumHerokuapp.Pages;
using TechTalk.SpecFlow;

namespace SeleniumHerokuapp.Steps
{
    [Binding]
    public class IFrameSteps
    {
        private readonly PageFactory _sut;

        private string _inputText;

        public IFrameSteps(PageFactory sut) => _sut = sut;

        [Given(@"the user is on the iFrame Page")]
        public void GivenTheUserIsOnTheIFramePage()
        {
            _sut.FramesPage.IFramePage.NavigateToPage();
        }
        
        [When(@"the user enters the text ""(.*)"" using their keyboard")]
        public void WhenTheUserEntersTheTextUsingTheirKeyboard(string input)
        {
            _inputText = input;
            _sut.FramesPage.IFramePage.EnterText(input);
        }
        
        [Then(@"the iFrame should append the input text to its default content text")]
        public void ThenTheIFrameShouldAppendTheInputTextToItsDefaultContentText()
        {
            var result = _sut.FramesPage.IFramePage.ReadText();

            Assert.That(result, Is.EqualTo("Your content goes here." + _inputText));
        }
    }
}
