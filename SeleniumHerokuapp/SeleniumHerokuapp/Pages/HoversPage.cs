using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumHerokuapp.Pages
{
    public sealed class HoversPage : WebPage, IPageNavigation
    {
        public HoversPage(IWebDriver driver) : base(driver) { }

        public enum ImageID
        {
            Image1 = 1,
            Image2 = 2,
            Image3 = 3
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

        public void HoverOverImage(ImageID imageID)
        {
            Actions actions = new Actions(Driver);
            switch (imageID)
            {
                case ImageID.Image1:
                    actions.MoveToElement(Image1);
                    break;
                case ImageID.Image2:
                    actions.MoveToElement(Image2);
                    break;
                case ImageID.Image3:
                    actions.MoveToElement(Image3);
                    break;
            }
            actions.Perform();
        }

        public string ReadSubHeaderTextForImage(ImageID imageID)
        {
            string headerText = null;
            switch (imageID)
            {
                case ImageID.Image1:
                    headerText = PageSubHeader1.Text;
                    break;
                case ImageID.Image2:
                    headerText = PageSubHeader2.Text;
                    break;
                case ImageID.Image3:
                    headerText = PageSubHeader3.Text;
                    break;
            }
            return headerText;
        }

        public void ClickViewProfileLink() => LinkViewProfile.Click();
    }
}
