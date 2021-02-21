using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class CheckboxesPage
    {
        private IWebDriver _driver;

        public CheckboxesPage(IWebDriver driver) => _driver = driver;

        private IWebElement Checkbox1 =>
            _driver.FindElement(By.CssSelector("input:nth-child(1)"));

        private IWebElement Checkbox2 =>
            _driver.FindElement(By.CssSelector("input:nth-child(3)"));

        public void ClickCheckbox1() => Checkbox1.Click();

        public void ClickCheckbox2() => Checkbox2.Click();
    }
}
