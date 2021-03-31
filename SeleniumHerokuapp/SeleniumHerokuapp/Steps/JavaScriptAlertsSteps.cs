using NUnit.Framework;
using SeleniumHerokuApp.Pages;
using TechTalk.SpecFlow;

namespace SeleniumHerokuApp.Steps
{
    [Binding]
    public class JavaScriptAlertsSteps
    {
        private readonly PageFactory _sut;

        public JavaScriptAlertsSteps(PageFactory sut) => _sut = sut;
        
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

        [When(@"the user enters the text ""(.*)""")]
        public void WhenTheUserEntersTheText(string input)
        {
            _sut.SharedIAlert.EnterInformation(input);
        }

        [Then(@"the page should display the result text ""(.*)"" for the interaction")]
        public void ThenThePageShouldDisplayTheResultTextForTheInteraction(string resultText)
        {
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo(resultText));
        }
    }
}
