using NUnit.Framework;
using SeleniumHerokuapp.Pages;
using TechTalk.SpecFlow;

namespace SeleniumHerokuapp.Steps
{
    [Binding]
    public class HoversSteps
    {
        private readonly PageFactory _sut;

        public HoversSteps(PageFactory sut) => _sut = sut;

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

        [When(@"the user clicks the profile link")]
        public void WhenTheUserClicksTheProfileLink()
        {
            _sut.HoversPage.ClickViewProfileLink();
        }

        [Then(@"the user should be able to see additional name information for the image (.*)")]
        public void ThenTheUserShouldBeAbleToSeeAdditionalNameInformationForTheImage(int id)
        {
            var result = _sut.HoversPage.ReadSubHeaderTextForImage(id);

            Assert.That(result, Is.EqualTo("name: user" + id));
        }

        [Then(@"the user should be redirected to a profile page for the selected user (.*)")]
        public void ThenTheUserShouldBeRedirectedToAProfilePageForTheSelectedUser(int id)
        {
            var result = _sut.Driver.Url;

            Assert.That(result, Is.EqualTo("http://the-internet.herokuapp.com/users/" + id));
        }
    }
}
