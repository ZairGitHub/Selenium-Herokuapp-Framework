using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples.Tests
{
    [TestFixture]
    public class CheckboxesTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [TestCase(1)]
        [TestCase(2)]
        public void ClickCheckbox_CheckboxId_TogglesCheckboxesTick(int id)
        {
            _sut.CheckboxesPage.NavigateToPage();
            var initialState = _sut.CheckboxesPage.IsCheckBoxTicked(id);

            _sut.CheckboxesPage.ClickCheckBox(id);
            var endState = _sut.CheckboxesPage.IsCheckBoxTicked(id);

            Assert.That(endState, Is.Not.EqualTo(initialState));
        }
    }
}
