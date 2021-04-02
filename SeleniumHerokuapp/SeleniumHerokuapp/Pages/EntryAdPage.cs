using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class EntryAdPage : WebPage, IPageNavigation
    {
        public EntryAdPage(IWebDriver driver) :base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.EntryAd);
        }

        private IWebElement LinkRestartAd =>
            Driver.FindElement(By.Id("restart-ad"));

        private IWebElement ModalTitle =>
            Driver.FindElement(By.CssSelector(".modal-title > h3"));

        private IWebElement ModalFooter =>
            Driver.FindElement(By.CssSelector(".modal-footer > p"));

        public string ReadModalWindowTitle() => ModalTitle.Text;

        public void ReenableModalWindow() => LinkRestartAd.Click();

        public void CloseModalWindow() => ModalFooter.Click();
    }
}
