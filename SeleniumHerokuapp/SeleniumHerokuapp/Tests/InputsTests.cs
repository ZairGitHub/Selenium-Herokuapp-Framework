using NUnit.Framework;
using SeleniumHerokuapp.Pages;

namespace SeleniumHerokuapp.Tests
{
    [TestFixture]
    public class InputsTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void InputNumber_DisplaysTheEnteredNumber()
        {
            _sut.InputsPage.NavigateToPage();
            const double input = 1.0;

            _sut.InputsPage.InputNumber(input);
            var result = _sut.InputsPage.ReadNumber();

            Assert.That(result, Is.EqualTo(input));
        }

        [Test]
        public void IncrementValue_IncrementsTheCurrentInput()
        {
            _sut.InputsPage.NavigateToPage();

            _sut.InputsPage.IncrementNumber();
            var result = _sut.InputsPage.ReadNumber();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void DecrementValue_DecrementsTheCurrentInput()
        {
            _sut.InputsPage.NavigateToPage();

            _sut.InputsPage.DecrementNumber();
            var result = _sut.InputsPage.ReadNumber();

            Assert.That(result, Is.EqualTo(-1));
        }
    }
}
