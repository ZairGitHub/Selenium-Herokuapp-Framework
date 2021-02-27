using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class SecureAreaPage : WebPage, IPageNavigation
    {
        public SecureAreaPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.SecureArea);
        }

        private IWebElement ButtonLogOut =>
            Driver.FindElement(By.CssSelector(".icon-2x"));

        private IWebElement TextUpdate => Driver.FindElement(By.Id("flash"));

        public void ClickLogoutButton() => ButtonLogOut.Click();

        public string ReadUpdateText() => TextUpdate.Text;
    }
}
