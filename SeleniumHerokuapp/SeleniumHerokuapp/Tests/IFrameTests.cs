using NUnit.Framework;
using SeleniumHerokuApp.Pages;

namespace SeleniumHerokuApp.Tests
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
        public void EnterText_InputText_EntersInputTextIntoTheIFrame()
        {
            _sut.FramesPage.IFramePage.NavigateToPage();
            var input = "input";

            _sut.FramesPage.IFramePage.EnterText(input);
            var result = _sut.FramesPage.IFramePage.ReadText();

            Assert.That(result, Is.EqualTo("Your content goes here." + input));
        }
    }
}
