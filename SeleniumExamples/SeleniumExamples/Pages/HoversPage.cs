using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumExamples.Pages
{
    public sealed class HoversPage : WebPage
    {
        private readonly Actions _actions;

        public HoversPage(IWebDriver driver) : base(driver)
        {
            _actions = new Actions(Driver);
        }

        private IWebElement Image1 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(3) > img"));

        private IWebElement Image2 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(2) > img"));

        private IWebElement Image3 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(1) > img"));

        private IWebElement LinkViewProfile =>
            Driver.FindElement(By.LinkText("View profile"));

        public void HoverOverImage(int id)
        {
            if (id == 1)
            {
                _actions.MoveToElement(Image1);
            }
            else if (id == 2)
            {
                _actions.MoveToElement(Image2);
            }
            else
            {
                _actions.MoveToElement(Image3);
            }
            _actions.Perform();
        }

        public string ReadSubHeaderText()
        {
            return Driver.FindElement(By.CssSelector("h5")).Text;
        }

        public void ClickViewProfileLink() => LinkViewProfile.Click();
    }
}
