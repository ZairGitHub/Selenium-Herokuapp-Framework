using System;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class DragAndDropSteps
    {
        [Given(@"the user is on the Drag and Drop Page")]
        public void GivenTheUserIsOnTheDragAndDropPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I drag a draggable element and drop it on top of another draggable element")]
        public void GivenIDragADraggableElementAndDropItOnTopOfAnotherDraggableElement()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the contents of the elements should be swapped ""(.*)""")]
        public void ThenTheContentsOfTheElementsShouldBeSwapped(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
