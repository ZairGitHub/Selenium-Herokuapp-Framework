using NUnit.Framework;
using SeleniumHerokuapp.Pages;

namespace SeleniumHerokuapp.Tests
{
    using static BrokenImagesPage;

    [TestFixture]
    public class BrokenImagesTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [TestCase(Image.Image1, true)]
        [TestCase(Image.Image2, true)]
        [TestCase(Image.Image3, false)]
        public void IsImageBroken_ReturnsTrueIfImageIsBroken(
            Image id, bool expectedCondition)
        {
            _sut.BrokenImagesPage.NavigateToPage();

            var result = _sut.BrokenImagesPage.IsImageBroken(id);

            Assert.That(result, Is.EqualTo(expectedCondition));
        }
    }
}
