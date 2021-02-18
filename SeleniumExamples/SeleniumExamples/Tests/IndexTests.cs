using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class IndexTests
    {
        private IndexPage _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new IndexPage(new FirefoxDriver());

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void AddRemoveElementsLink_HomePage_RedirectsToAddRemovePage()
        {
            //_website.NavigateToPage();
            //_driver.FindElement(By.LinkText("Add/Remove Elements")).Click();

            //var result = GetAddButton().Text;

            //Assert.That(result, Is.EqualTo("Add Element"));
        }
    }
}
