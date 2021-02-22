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

        [TestCase(1)]
        [TestCase(2)]
        public void ClickCheckbox_TogglesCheckboxesTick(int id)
        {
            _sut.NavigateToCheckboxesPage();

            var initialState = _sut.CheckboxesPage.IsCheckBoxTicked(id);
            _sut.CheckboxesPage.ClickCheckBox(id);
            var endState = _sut.CheckboxesPage.IsCheckBoxTicked(id);

            Assert.That(initialState, Is.Not.EqualTo(endState));
        }
    }
}
