using NUnit.Framework;
using SeleniumHerokuapp.Pages;

namespace SeleniumHerokuapp.Tests
{
    using static CheckboxesPage;

    [TestFixture]
    public class CheckboxesTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [TestCase(CheckboxID.Checkbox1)]
        [TestCase(CheckboxID.Checkbox2)]
        public void ClickCheckbox_CheckboxId_TogglesCheckboxesTick(
            CheckboxID checkboxID)
        {
            _sut.CheckboxesPage.NavigateToPage();
            var initialState = _sut.CheckboxesPage.IsCheckboxTicked(checkboxID);

            _sut.CheckboxesPage.ClickCheckbox(checkboxID);
            var endState = _sut.CheckboxesPage.IsCheckboxTicked(checkboxID);

            Assert.That(endState, Is.Not.EqualTo(initialState));
        }
    }
}
