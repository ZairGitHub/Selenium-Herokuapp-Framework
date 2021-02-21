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

        public bool IsCheckBoxTicked(int id)
        {
            return (id == 1) ? Checkbox1.Selected : Checkbox2.Selected;
        }

        public void ClickCheckBox(int id)
        {
            if (id == 1)
            {
                Checkbox1.Click();
            }
            else
            {
                Checkbox2.Click();
            }
        }
    }
}
