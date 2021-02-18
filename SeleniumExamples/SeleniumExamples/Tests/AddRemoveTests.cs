using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class AddRemoveTests
    {
        private AddRemovePage _website;

        private IWebDriver _driver;
        
        private IWebElement GetAddButton()
        {
            return _driver.FindElement(By.CssSelector("button"));
        }

        private IWebElement GetDeleteButton()
        {
            return _driver.FindElement(By.CssSelector(".added-manually"));
        }

        private ReadOnlyCollection<IWebElement> GetDeleteButtons()
        {
            return _driver.FindElements(By.CssSelector(".added-manually"));
        }

        private void NavigateToPage(string url) => _driver.Navigate().GoToUrl(url);

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new FirefoxDriver();
            _website = new AddRemovePage(new FirefoxDriver());
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
            _website.CloseDriver();
        }

        [Ignore("Move to a seperate home page test class")]
        [Test]
        public void AddRemoveElementsLink_HomePage_RedirectsToAddRemovePage()
        {
            _website.NavigateToPage();
            _driver.FindElement(By.LinkText("Add/Remove Elements")).Click();

            var result = GetAddButton().Text;

            Assert.That(result, Is.EqualTo("Add Element"));
        }

        [Test]
        public void AddButton_CreatesADeleteButton()
        {
            _website.NavigateToPage();
            _website.ClickAddButton();

            var result = _website.CountNumberOfDeleteButtons();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void AddButton_ClickedMultipleTimes_CreatesMultipleDeleteButtons()
        {
            _website.NavigateToPage();
            var addButton = GetAddButton();
            addButton.Click();
            addButton.Click();
            addButton.Click();

            var result = GetDeleteButtons().Count;

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void DeleteButton_RemovesDeleteButton()
        {
            _website.NavigateToPage();
            GetAddButton().Click();
            GetDeleteButton().Click();

            var result = GetDeleteButtons().Count;

            Assert.That(result, Is.Zero);
        }
    }
}
