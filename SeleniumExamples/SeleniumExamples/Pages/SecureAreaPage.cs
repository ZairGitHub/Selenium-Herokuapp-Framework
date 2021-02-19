using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class SecureAreaPage
    {
        private readonly IWebDriver _driver;

        public SecureAreaPage(IWebDriver driver) => _driver = driver;

        private IWebElement ButtonLogOut => _driver.FindElement(By.CssSelector(".icon-2x"));

        public void ClickLogoutButton() => ButtonLogOut.Click();
    }
}
