using NUnit.Framework;
using SeleniumHerokuapp.Pages;

namespace SeleniumHerokuapp.Tests
{
    using static HoversPage;

    [TestFixture]
    public class HoversTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [TestCase(ImageID.Image1)]
        [TestCase(ImageID.Image2)]
        [TestCase(ImageID.Image3)]
        public void HoverOverImage_ImageId_DiplaysCorrectSubHeaders(ImageID imageID)
        {
            _sut.HoversPage.NavigateToPage();

            _sut.HoversPage.HoverOverImage(imageID);
            var result = _sut.HoversPage.ReadSubHeaderTextForImage(imageID);

            Assert.That(result, Is.EqualTo("name: user" + (int)imageID));
        }

        [TestCase(ImageID.Image1)]
        [TestCase(ImageID.Image2)]
        [TestCase(ImageID.Image3)]
        public void HoverOverImage_ImageId_DisplaysCorrectLinks(ImageID imageID)
        {
            _sut.HoversPage.NavigateToPage();

            _sut.HoversPage.HoverOverImage(imageID);
            _sut.HoversPage.ClickViewProfileLink();
            var result = _sut.Driver.Url;

            Assert.That(result, Is.EqualTo(
                ConfigReader.Index + "users/" + (int)imageID));
        }
    }
}
