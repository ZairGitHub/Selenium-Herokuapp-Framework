using NUnit.Framework;
using SeleniumExamples.Pages;
using TechTalk.SpecFlow;

namespace SeleniumExamples.Steps
{
    [Binding]
    public class HoversSteps
    {
        private WebsitePOM _sut;

        [BeforeScenario]
        public void BeforeScenario() => _sut = new WebsitePOM(StaticDriver.Type);

        [AfterScenario]
        public void AfterScenario() => _sut.CloseDriver();

        [Given(@"the user is on the Hovers page")]
        public void GivenTheUserIsOnTheHoversPage()
        {
            _sut.HoversPage.NavigateToPage();
        }
        
        [When(@"the user hovers over the image (.*)")]
        public void WhenTheUserHoversOverTheImage(int id)
        {
            _sut.HoversPage.HoverOverImage(id);
        }

        [Then(@"the user should be able to see additional name information for the image (.*)")]
        public void ThenTheUserShouldBeAbleToSeeAdditionalNameInformationForTheImage(int id)
        {
            var result = _sut.HoversPage.ReadSubHeaderTextForImage(id);

            Assert.That(result, Is.EqualTo("name: user" + id));
        }
    }
}
