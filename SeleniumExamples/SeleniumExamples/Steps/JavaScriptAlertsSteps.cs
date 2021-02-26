using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class JavaScriptAlertsSteps
    {
        private readonly WebsitePOM _sut = new WebsitePOM(StaticDriver.Type);

        [AfterScenario]
        public void AfterScenario() => _sut.CloseDriver();

        [Given(@"the user is on the JavaScriptAlerts page")]
        public void GivenTheUserIsOnTheJavaScriptAlertsPage()
        {
            _sut.JavaScriptAlertsPage.NavigateToPage();
        }
        
        [When(@"the user clicks the JSAlert button")]
        public void WhenTheUserClicksTheJSAlertButton()
        {
            _sut.JavaScriptAlertsPage.ClickJSAlertButton();
        }

        [When(@"the user clicks the JSConfirm button")]
        public void WhenTheUserClicksTheJSConfirmButton()
        {
            _sut.JavaScriptAlertsPage.ClickJSConfirmButton();
        }

        [When(@"the user clicks the JSPrompt button")]
        public void WhenTheUserClicksTheJSPromptButton()
        {
            _sut.JavaScriptAlertsPage.ClickJSPromptButton();
        }

        [When(@"the user clicks the cancel button")]
        public void WhenTheUserClicksTheCancelButton()
        {
            _sut.SharedIAlert.ClickCancelButton();
        }

        [When(@"the user clicks the OK button")]
        public void WhenTheUserClicksTheOKButton()
        {
            _sut.SharedIAlert.ClickOKButton();
        }

        [Then(@"the page should display the result text ""(.*)"" for the interaction")]
        public void ThenThePageShouldDisplayTheResultTextForTheInteraction(string resultText)
        {
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo(resultText));
        }
    }
}
