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

        [TestCase(Images.Image1, true)]
        [TestCase(Images.Image2, true)]
        [TestCase(Images.Image3, false)]
        public void IsImageBroken_ReturnsTrueIfImageIsBroken(
            Images id, bool expectedCondition)
        {
            _sut.BrokenImagesPage.NavigateToPage();

            var result = _sut.BrokenImagesPage.IsImageBroken(id);

            Assert.That(result, Is.EqualTo(expectedCondition));
        }
    }
}
