using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumExamples.Pages
{
    public sealed class HoversPage : WebPage, IPageNavigation
    {
        public HoversPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL("http://the-internet.herokuapp.com/hovers");
        }

        private IWebElement PageSubHeader1 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(3) h5"));

        private IWebElement PageSubHeader2 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(4) h5"));

        private IWebElement PageSubHeader3 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(5) h5"));

        private IWebElement Image1 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(3) > img"));

        private IWebElement Image2 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(4) > img"));

        private IWebElement Image3 =>
            Driver.FindElement(By.CssSelector(".figure:nth-child(5) > img"));

        private IWebElement LinkViewProfile =>
            Driver.FindElement(By.LinkText("View profile"));

        public void HoverOverImage(int id)
        {
            Actions actions = new Actions(Driver);
            if (id == 1)
            {
                actions.MoveToElement(Image1);
            }
            else if (id == 2)
            {
                actions.MoveToElement(Image2);
            }
            else
            {
                actions.MoveToElement(Image3);
            }
            actions.Perform();
        }

        public string ReadSubHeaderTextForImage(int id)
        {
            string headerText;
            if (id == 1)
            {
                headerText = PageSubHeader1.Text;
            }
            else if (id == 2)
            {
                headerText = PageSubHeader2.Text;
            }
            else
            {
                headerText = PageSubHeader3.Text;
            }
            return headerText;
        }

        public void ClickViewProfileLink() => LinkViewProfile.Click();
    }
}
