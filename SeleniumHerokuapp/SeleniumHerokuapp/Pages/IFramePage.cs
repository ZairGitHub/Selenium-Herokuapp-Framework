using OpenQA.Selenium;

namespace SeleniumHerokuApp.Pages
{
    public sealed class IFramePage : WebPage, IPageNavigation
    {
        public IFramePage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.IFrame);
        }

        private IWebElement TextParagraph =>
            Driver.FindElement(By.CssSelector("p"));

        public void EnterText(string text)
        {
            Driver.SwitchTo().Frame(0);
            TextParagraph.SendKeys(text);
        }

        public string ReadText() => TextParagraph.Text;
    }
}
