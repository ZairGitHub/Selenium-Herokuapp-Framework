using NUnit.Framework;
using SeleniumHerokuapp.Pages;

namespace SeleniumHerokuapp.Tests
{
    [TestFixture]
    public class BrokenImagesTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, false)]
        public void IsImageBroken_ReturnsTrueIfImageIsBroken(
            int id, bool expectedCondition)
        {
            _sut.BrokenImagesPage.NavigateToPage();

            var result = _sut.BrokenImagesPage.IsImageBroken(id);

            Assert.That(result, Is.EqualTo(expectedCondition));
        }
    }
}
