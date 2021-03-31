using NUnit.Framework;
using SeleniumHerokuApp.Pages;
using TechTalk.SpecFlow;

namespace SeleniumHerokuApp.Steps
{
    [Binding]
    public class DragAndDropSteps
    {
        private readonly PageFactory _sut;

        public DragAndDropSteps(PageFactory sut) => _sut = sut;

        [Given(@"the user is on the Drag and Drop Page")]
        public void GivenTheUserIsOnTheDragAndDropPage()
        {
            _sut.DragAndDropPage.NavigateToPage();
        }
        
        [Given(@"I drag a draggable element and drop it on top of another draggable element")]
        public void GivenIDragADraggableElementAndDropItOnTopOfAnotherDraggableElement()
        {
            _sut.DragAndDropPage.SwapDraggableContents();
        }
        
        [Then(@"the contents of the elements should be swapped ""(.*)""")]
        public void ThenTheContentsOfTheElementsShouldBeSwapped(bool hasSwapped)
        {
            var result = _sut.DragAndDropPage.HaveDraggableContentsBeenSwapped();

            Assert.That(result, Is.EqualTo(hasSwapped));
        }
    }
}
