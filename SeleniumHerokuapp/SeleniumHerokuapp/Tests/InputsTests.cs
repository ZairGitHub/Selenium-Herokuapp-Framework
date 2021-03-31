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
        public void InputNumber()
        {
            _sut.InputsPage.NavigateToPage();

            _sut.InputsPage.EnterValue(9);
            var result =  _sut.InputsPage.ReadValue();

            Assert.That(result, Is.EqualTo(9.ToString()));
        }

        [Test]
        public void Increment()
        {
            _sut.InputsPage.NavigateToPage();

            _sut.InputsPage.IncreaseValue();
            var result = _sut.InputsPage.ReadValue();

            Assert.That(result, Is.EqualTo("1"));
        }

        [Test]
        public void Decrement()
        {
            _sut.InputsPage.NavigateToPage();

            _sut.InputsPage.DecreaseValue();
            var result = _sut.InputsPage.ReadValue();

            Assert.That(result, Is.EqualTo("-1"));
        }
    }
}
