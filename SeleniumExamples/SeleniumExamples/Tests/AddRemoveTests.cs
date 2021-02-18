using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples
{
    [TestFixture]
    public class AddRemoveTests
    {
        private const string _urlBase = "http://the-internet.herokuapp.com/";
        private const string _urlElements = _urlBase + "add_remove_elements/";

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
        public void OneTimeSetUp() => _driver = new FirefoxDriver();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _driver.Quit();

        [Test]
        public void AddRemoveElementsLink_HomePage_RedirectsToAddRemovePage()
        {
            NavigateToPage(_urlBase);
            _driver.FindElement(By.LinkText("Add/Remove Elements")).Click();

            var result = GetAddButton().Text;

            Assert.That(result, Is.EqualTo("Add Element"));
        }

        [Test]
        public void AddButton_CreatesADeleteButton()
        {
            NavigateToPage(_urlElements);
            GetAddButton().Click();
            
            var result = GetDeleteButton().Text;

            Assert.That(result, Is.EqualTo("Delete"));
        }

        [Test]
        public void AddButton_ClickedMultipleTimes_CreatesMultipleDeleteButtons()
        {
            NavigateToPage(_urlElements);
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
            NavigateToPage(_urlElements);
            GetAddButton().Click();
            GetDeleteButton().Click();

            var result = GetDeleteButtons().Count;

            Assert.That(result, Is.Zero);
        }
    }
}
