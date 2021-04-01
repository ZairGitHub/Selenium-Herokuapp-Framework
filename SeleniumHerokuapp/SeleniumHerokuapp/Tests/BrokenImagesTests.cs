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

        [TestCase(ImageID.Image1, true)]
        [TestCase(ImageID.Image2, true)]
        [TestCase(ImageID.Image3, false)]
        public void IsImageBroken_ReturnsTrueIfImageIsBroken(
            ImageID imageID, bool expectedCondition)
        {
            _sut.BrokenImagesPage.NavigateToPage();

            var result = _sut.BrokenImagesPage.IsImageBroken(imageID);

            Assert.That(result, Is.EqualTo(expectedCondition));
        }
    }
}
