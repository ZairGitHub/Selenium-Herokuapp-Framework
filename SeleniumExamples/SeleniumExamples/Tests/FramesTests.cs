using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    [TestFixture]
    public class FramesTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void NestedFramesLink_RedirectsToNestedFramesPage()
        {
            _sut.FramesPage.NavigateToPage();

            _sut.FramesPage.ClickNestedFramesLink();
            var result = _sut.Driver.Url;

            Assert.That(result,
                Is.EqualTo(ConfigReader.Index + ConfigReader.NestedFrames));
        }

        [Test]
        public void IFrameLink_RedirectsToNestedFramesPage()
        {
            _sut.FramesPage.NavigateToPage();

            _sut.FramesPage.ClickIFrameLink();
            var result = _sut.SharedHTML.ReadPageHeaderText();

            Assert.That(result, Contains.Substring("iFrame"));
        }
    }
}
