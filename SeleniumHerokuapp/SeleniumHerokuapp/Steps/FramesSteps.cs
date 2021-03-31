using SeleniumHerokuapp.Pages;
using TechTalk.SpecFlow;

namespace SeleniumHerokuapp.Steps
{
    [Binding]
    public class FramesSteps
    {
        private readonly PageFactory _sut;

        public FramesSteps(PageFactory sut) => _sut = sut;

        [Given(@"the user is on the Frames page")]
        public void GivenTheUserIsOnTheFramesPage()
        {
            _sut.FramesPage.NavigateToPage();
        }
        
        [When(@"the user clicks the NestedFrames link")]
        public void WhenTheUserClicksTheNestedFramesLink()
        {
            _sut.FramesPage.ClickNestedFramesLink();
        }
        
        [When(@"the user clicks the iFrames link")]
        public void WhenTheUserClicksTheIFramesLink()
        {
            _sut.FramesPage.ClickIFrameLink();
        }
    }
}
