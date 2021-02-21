using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class CheckboxesTests
    {
        private WebsitePOM _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void Checkbox1()
        {
            _sut.NavigateToCheckboxesPage();

            _sut.CheckboxesPage.ClickCheckbox1();

            Assert.Fail();
        }
    }
}
