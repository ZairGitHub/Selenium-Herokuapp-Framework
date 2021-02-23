using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class HoversTests
    {
        private WebsitePOM _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Hover_SubHeaders(int id)
        {
            _sut = new WebsitePOM();
            _sut.NavigateToHoversPage();

            _sut.HoversPage.HoverOverImage(id);
            var result = _sut.HoversPage.ReadSubHeaderTextForImage(id);

            Assert.That(result, Is.EqualTo("name: user" + id));

            _sut.CloseDriver();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Hover_Links(int id)
        {
            //_sut = new WebsitePOM();
            _sut.NavigateToHoversPage();

            _sut.HoversPage.HoverOverImage(id);
            _sut.HoversPage.ClickViewProfileLink();
            var result = _sut.Driver.Url;

            Assert.That(result, Is.EqualTo("http://the-internet.herokuapp.com/users/" + id));

            //_sut.CloseDriver();
        }
    }
}
