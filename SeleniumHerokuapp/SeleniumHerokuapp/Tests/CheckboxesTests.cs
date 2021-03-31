using NUnit.Framework;
using SeleniumHerokuApp.Pages;

namespace SeleniumHerokuApp.Tests
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
            var initialState = _sut.CheckboxesPage.IsCheckboxTicked(id);

            _sut.CheckboxesPage.ClickCheckbox(id);
            var endState = _sut.CheckboxesPage.IsCheckboxTicked(id);

            Assert.That(endState, Is.Not.EqualTo(initialState));
        }
    }
}
