using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumHerokuapp.Pages
{
    public sealed class HoversPage : WebPage, IPageNavigation
    {
        public HoversPage(IWebDriver driver) : base(driver) { }

        public enum Image
        {
            Image1,
            Image2,
            Image3
        }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Hovers);
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

        public void HoverOverImage(Image id)
        {
            Actions actions = new Actions(Driver);
            switch (id)
            {
                case Image.Image1:
                    actions.MoveToElement(Image1);
                    break;
                case Image.Image2:
                    actions.MoveToElement(Image2);
                    break;
                case Image.Image3:
                    actions.MoveToElement(Image3);
                    break;
            }
            actions.Perform();
        }

        public string ReadSubHeaderTextForImage(Image id)
        {
            string headerText = null;
            switch (id)
            {
                case Image.Image1:
                    headerText = PageSubHeader1.Text;
                    break;
                case Image.Image2:
                    headerText = PageSubHeader2.Text;
                    break;
                case Image.Image3:
                    headerText = PageSubHeader3.Text;
                    break;
            }
            return headerText;
        }

        public void ClickViewProfileLink() => LinkViewProfile.Click();
    }
}
