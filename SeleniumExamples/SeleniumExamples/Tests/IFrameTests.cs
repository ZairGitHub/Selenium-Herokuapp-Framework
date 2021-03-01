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
        public void InputText()
        {
            _sut.IFramePage.NavigateToPage();

            _sut.IFramePage.EnterText(_input);
            var result = _sut.IFramePage.ReadText();

            Assert.That(result, Is.EqualTo(_defaultTextString + _input));
        }

        [Test]
        public void SelectAllText()
        {
            _sut.IFramePage.NavigateToPage();

            _sut.IFramePage.SelectAllText();
            _sut.IFramePage.EnterText(_input);
            var result = _sut.IFramePage.ReadText();

            Assert.That(result, Is.EqualTo(_input));
        }

        [Test]
        public void Undo()
        {
            _sut.IFramePage.NavigateToPage();

            _sut.IFramePage.EnterText(_input);
            _sut.IFramePage.ClickUndoButton();

            var result = _sut.IFramePage.ReadText();

            Assert.That(result, Is.EqualTo(_defaultTextString));
        }

        [Test]
        public void Redo()
        {
            _sut.IFramePage.NavigateToPage();

            _sut.IFramePage.EnterText(_input);
            _sut.IFramePage.ClickUndoButton();
            _sut.IFramePage.ClickRedoButton();

            var result = _sut.IFramePage.ReadText();

            Assert.That(result, Is.EqualTo(_defaultTextString + _input));
        }
    }
}
