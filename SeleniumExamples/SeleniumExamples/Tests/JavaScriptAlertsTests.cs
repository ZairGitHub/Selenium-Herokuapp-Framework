using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class JavaScriptAlertsTests
    {
        private WebsitePOM _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();
    }
}
