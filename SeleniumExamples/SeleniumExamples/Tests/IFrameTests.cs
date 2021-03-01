using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    [TestFixture]
    public class IFrameTests
    {
        private const string _defaultTextString = "Your content goes here.";
        private const string _input = "input";

        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void IFrame_CanProcessInputText()
        {
            _sut.FramesPage.IFramePage.NavigateToPage();

            _sut.FramesPage.IFramePage.EnterText(_input);
            var result = _sut.FramesPage.IFramePage.ReadText();

            Assert.That(result, Is.EqualTo(_defaultTextString + _input));
        }
    }
}
