using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class AddRemoveTests
    {
        private AddRemovePage _website;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _website = new AddRemovePage(new FirefoxDriver());
        
        [OneTimeTearDown]
        public void OneTimeTearDown() => _website.CloseDriver();
        
        [Ignore("Move to a seperate home page test class")]
        [Test]
        public void AddRemoveElementsLink_HomePage_RedirectsToAddRemovePage()
        {
            //_website.NavigateToPage();
            //_driver.FindElement(By.LinkText("Add/Remove Elements")).Click();

            //var result = GetAddButton().Text;

            //Assert.That(result, Is.EqualTo("Add Element"));
        }

        [Test]
        public void AddButton_CreatesADeleteButtonForEachClick()
        {
            _website.NavigateToPage();

            _website.ClickAddButton();
            _website.ClickAddButton();
            _website.ClickAddButton();
            var result = _website.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void DeleteButton_RemovesADeleteButtonForEachClick()
        {
            _website.NavigateToPage();

            _website.ClickAddButton();
            _website.ClickAddButton();
            _website.ClickAddButton();
            _website.ClickAnyDeleteButton();
            _website.ClickAnyDeleteButton();
            var result = _website.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
