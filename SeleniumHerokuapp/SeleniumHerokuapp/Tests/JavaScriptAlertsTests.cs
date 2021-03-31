using NUnit.Framework;
using SeleniumHerokuApp.Pages;

namespace SeleniumHerokuApp.Tests
{
    [TestFixture]
    public class JavaScriptAlertsTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void ClickJSAlertButton_ClickOKButton_UpdatesResultMessage()
        {
            _sut.JavaScriptAlertsPage.NavigateToPage();

            _sut.JavaScriptAlertsPage.ClickJSAlertButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You successfully clicked an alert"));
        }

        [Test]
        public void ClickJSConfirmButton_ClickCancelButton_UpdatesResultMessage()
        {
            _sut.JavaScriptAlertsPage.NavigateToPage();

            _sut.JavaScriptAlertsPage.ClickJSConfirmButton();
            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You clicked: Cancel"));
        }

        [Test]
        public void ClickJSConfirmButton_ClickOKButton_UpdatesResultMessage()
        {
            _sut.JavaScriptAlertsPage.NavigateToPage();

            _sut.JavaScriptAlertsPage.ClickJSConfirmButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You clicked: Ok"));
        }

        [Test]
        public void ClickJSPromptButton_ClickCancelButton_UpdatesResultMessage()
        {
            _sut.JavaScriptAlertsPage.NavigateToPage();

            _sut.JavaScriptAlertsPage.ClickJSPromptButton();
            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You entered: null"));
        }

        [Test]
        public void ClickJSPromptButton_ClickOKButton_UpdatesResultMessage()
        {
            _sut.JavaScriptAlertsPage.NavigateToPage();

            _sut.JavaScriptAlertsPage.ClickJSPromptButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You entered:"));
        }

        [Test]
        public void ClickJSPromptButton_InputIsNotPurelyWhitespacesAndClickOKButton_UpdatesResultMessageWithSingleWhitespaceReplacingInputWhitespaces()
        {
            _sut.JavaScriptAlertsPage.NavigateToPage();

            _sut.JavaScriptAlertsPage.ClickJSPromptButton();
            _sut.SharedIAlert.EnterInformation(" i  np  u  t  1 ");
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You entered: i np u t 1"));
        }
    }
}
