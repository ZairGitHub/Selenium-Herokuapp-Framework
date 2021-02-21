using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class JavaScriptAlertsTests
    {
        private WebsitePOM _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void AlertButtonTest()
        {
            _sut.NavigateToJavaScriptAlertsPage();

            _sut.JavaScriptAlertsPage.ClickJSAlertButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You successfully clicked an alert"));
            
        }
    }
}
