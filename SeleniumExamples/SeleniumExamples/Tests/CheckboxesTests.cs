using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class CheckboxesTests
    {
        private WebsitePOM<FirefoxDriver> _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM<FirefoxDriver>();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [TestCase(1)]
        [TestCase(2)]
        public void ClickCheckbox_TogglesCheckboxesTick(int id)
        {
            _sut.CheckboxesPage.NavigateToPage();

            var initialState = _sut.CheckboxesPage.IsCheckBoxTicked(id);
            _sut.CheckboxesPage.ClickCheckBox(id);
            var endState = _sut.CheckboxesPage.IsCheckBoxTicked(id);

            Assert.That(initialState, Is.Not.EqualTo(endState));
        }
    }
}
