using NUnit.Framework;
using SeleniumHerokuapp.Pages;
using SeleniumHerokuapp.Helpers;

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
        
        [TestCase(KeyCodes.Tab, "TAB")]
        [TestCase(KeyCodes.BackSpace, "BACK_SPACE")]
        [TestCase(KeyCodes.Escape, "ESCAPE")]
        public void Tab(string keyCode, string key)
        {
            _sut.KeyPressesPage.NavigateToPage();

            _sut.KeyPressesPage.PressKey(keyCode);
            var result = _sut.KeyPressesPage.ReadInformation();

            Assert.That(result, Is.EqualTo("You entered: " + key));
        }
    }
}
