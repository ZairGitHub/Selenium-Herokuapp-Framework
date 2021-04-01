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
        public void DecimalNumber()
        {
            _sut.InputsPage.NavigateToPage();

            _sut.InputsPage.EnterValue(9.3);
            _sut.InputsPage.IncrementValue();
            var result = _sut.InputsPage.ReadValue();

            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void InputNumber()
        {
            _sut.InputsPage.NavigateToPage();
            int input = 9;

            _sut.InputsPage.EnterValue(input);
            var result =  _sut.InputsPage.ReadValue();

            Assert.That(result, Is.EqualTo(input));
        }

        [Test]
        public void IncrementValue_IncrementsTheCurrentInput()
        {
            _sut.InputsPage.NavigateToPage();

            _sut.InputsPage.IncrementValue();
            var result = _sut.InputsPage.ReadValue();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void DecrementValue_DecrementsTheCurrentInput()
        {
            _sut.InputsPage.NavigateToPage();

            _sut.InputsPage.DecrementValue();
            var result = _sut.InputsPage.ReadValue();

            Assert.That(result, Is.EqualTo(-1));
        }
    }
}
