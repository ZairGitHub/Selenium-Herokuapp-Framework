using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    [TestFixture]
    public class HoversTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void HoverOverImage_ImageId_DiplaysCorrectSubHeaders(int id)
        {
            _sut.HoversPage.NavigateToPage();

            _sut.HoversPage.HoverOverImage(id);
            var result = _sut.HoversPage.ReadSubHeaderTextForImage(id);

            Assert.That(result, Is.EqualTo("name: user" + id));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void HoverOverImage_ImageId_DisplaysCorrectLinks(int id)
        {
            _sut.HoversPage.NavigateToPage();

            _sut.HoversPage.HoverOverImage(id);
            _sut.HoversPage.ClickViewProfileLink();
            var result = _sut.Driver.Url;

            Assert.That(result, Is.EqualTo("http://the-internet.herokuapp.com/users/" + id));
        }
    }
}
