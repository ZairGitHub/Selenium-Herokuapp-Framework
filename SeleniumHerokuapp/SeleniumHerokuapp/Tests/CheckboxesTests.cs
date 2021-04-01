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

        [TestCase(Checkbox.Checkbox1)]
        [TestCase(Checkbox.Checkbox2)]
        public void ClickCheckbox_CheckboxId_TogglesCheckboxesTick(Checkbox id)
        {
            _sut.CheckboxesPage.NavigateToPage();
            var initialState = _sut.CheckboxesPage.IsCheckboxTicked(id);

            _sut.CheckboxesPage.ClickCheckbox(id);
            var endState = _sut.CheckboxesPage.IsCheckboxTicked(id);

            Assert.That(endState, Is.Not.EqualTo(initialState));
        }
    }
}
