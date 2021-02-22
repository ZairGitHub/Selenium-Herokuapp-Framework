using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumExamples.Pages
{
    public sealed class HoversPage : WebPage
    {
        private Actions _actions;

        public HoversPage(IWebDriver driver) : base(driver) { }

        private IWebElement HeaderName1 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(3) h5"));

        private IWebElement HeaderName2 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(2) h5"));

        private IWebElement HeaderName3 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(1) h5"));

        private IWebElement Image1 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(3) > img"));

        private IWebElement Image2 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(2) > img"));

        private IWebElement Image3 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(1) > img"));

        private IWebElement LinkViewProfile =>
            Driver.FindElement(By.LinkText("View profile"));

        public void HoverOverImage1()
        {
            _actions = new Actions(Driver);
            _actions.MoveToElement(Image1).Perform();
        }

        public string ReadAnyHeader()
        {
            return Driver.FindElement(By.CssSelector("h5")).Text;
        }

        public void ClickViewProfileLink() => LinkViewProfile.Click();
    }
}
