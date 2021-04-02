using NUnit.Framework;
using SeleniumHerokuapp.Pages;

namespace SeleniumHerokuapp.Tests
{
    [TestFixture]
    public class EntryAdTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Ignore("Only works for FirefoxDriver. Modal window does not appear in ChromeDriver.")]
        [Test]
        public void ReadModalTitle()
        {
            _sut.Driver.Manage().Cookies.DeleteAllCookies();
            _sut.EntryAdPage.NavigateToPage();

            var result = _sut.EntryAdPage.ReadModalWindowTitle();

            Assert.That(result, Is.EqualTo("THIS IS A MODAL WINDOW"));
        }

        [Ignore("Only works for FirefoxDriver. Modal window does not appear in ChromeDriver.")]
        [Test]
        public void CloseModalWindow()
        {
            _sut.Driver.Manage().Cookies.DeleteAllCookies();
            _sut.EntryAdPage.NavigateToPage();

            _sut.EntryAdPage.CloseModalWindow();
            var result = _sut.EntryAdPage.ReadModalWindowTitle();

            Assert.That(result, Is.Empty);
        }
    }
}
