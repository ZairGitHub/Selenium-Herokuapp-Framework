using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    [TestFixture]
    public class IFrameTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void InputText()
        {
            _sut.IFramePage.NavigateToPage();

            _sut.IFramePage.EnterText(OpenQA.Selenium.Keys.Backspace);
            var result = _sut.IFramePage.ReadText();

            Assert.That(result, Is.EqualTo("Your content goes here"));
        }
    }
}
