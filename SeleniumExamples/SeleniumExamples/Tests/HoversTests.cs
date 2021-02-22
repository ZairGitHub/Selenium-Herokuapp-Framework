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

        [Test]
        public void Hover()
        {
            _sut.NavigateToHoversPage();

            _sut.HoversPage.HoverOverImage(1);
            var result = _sut.HoversPage.ReadSubHeaderText();

            Assert.That(result, Is.EqualTo("name: user1"));
        }
    }
}
