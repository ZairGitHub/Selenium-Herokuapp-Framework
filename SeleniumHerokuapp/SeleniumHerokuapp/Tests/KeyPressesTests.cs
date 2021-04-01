using NUnit.Framework;
using SeleniumHerokuapp.Pages;

namespace SeleniumHerokuapp.Tests
{
    [TestFixture]
    public class KeyPressesTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void Tab()
        {
            _sut.KeyPressesPage.NavigateToPage();

            _sut.KeyPressesPage.PressTabKey();
            var result = _sut.KeyPressesPage.ReadInformation();

            Assert.That(result, Is.EqualTo("You entered: TAB"));
        }
    }
}
