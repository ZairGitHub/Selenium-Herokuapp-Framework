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

        [TestCase(Image.Image1, 1)]
        [TestCase(Image.Image2, 2)]
        [TestCase(Image.Image3, 3)]
        public void HoverOverImage_ImageId_DiplaysCorrectSubHeaders(
            Image id, int userID)
        {
            _sut.HoversPage.NavigateToPage();

            _sut.HoversPage.HoverOverImage(id);
            var result = _sut.HoversPage.ReadSubHeaderTextForImage(id);

            Assert.That(result, Is.EqualTo("name: user" + userID));
        }

        [TestCase(Image.Image1, 1)]
        [TestCase(Image.Image2, 2)]
        [TestCase(Image.Image3, 3)]
        public void HoverOverImage_ImageId_DisplaysCorrectLinks(
            Image id, int userID)
        {
            _sut.HoversPage.NavigateToPage();

            _sut.HoversPage.HoverOverImage(id);
            _sut.HoversPage.ClickViewProfileLink();
            var result = _sut.Driver.Url;

            Assert.That(result,
                Is.EqualTo("http://the-internet.herokuapp.com/users/" + userID));
        }
    }
}
