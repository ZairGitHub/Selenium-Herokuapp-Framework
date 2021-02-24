using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class HoversTests
    {
        private WebsitePOM<FirefoxDriver> _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM<FirefoxDriver>();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Hover_SubHeaders(int id)
        {
            _sut.HoversPage.NavigateToPage();

            _sut.HoversPage.HoverOverImage(id);
            var result = _sut.HoversPage.ReadSubHeaderTextForImage(id);

            Assert.That(result, Is.EqualTo("name: user" + id));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Hover_Links(int id)
        {
            _sut.HoversPage.NavigateToPage();

            _sut.HoversPage.HoverOverImage(id);
            _sut.HoversPage.ClickViewProfileLink();
            var result = _sut.Driver.Url;

            Assert.That(result, Is.EqualTo("http://the-internet.herokuapp.com/users/" + id));
        }
    }
}
