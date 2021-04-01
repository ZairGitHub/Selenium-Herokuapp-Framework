using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class BrokenImagesPage : WebPage, IPageNavigation
    {
        public BrokenImagesPage(IWebDriver driver) : base(driver) { }

        public enum Images
        {
            Image1,
            Image2,
            Image3
        }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.BrokenImages);
        }

        public IWebElement Image1 =>
            Driver.FindElement(By.CssSelector("img:nth-child(2)"));

        public IWebElement Image2 =>
            Driver.FindElement(By.CssSelector("img:nth-child(3)"));

        public IWebElement Image3 =>
            Driver.FindElement(By.CssSelector("img:nth-child(4)"));

        public bool IsImageBroken(Images id)
        {
            IWebElement image = null;
            switch (id)
            {
                case Images.Image1:
                    image = Image1;
                    break;
                case Images.Image2:
                    image = Image2;
                    break;
                case Images.Image3:
                    image = Image3;
                    break;
            }
            return image.GetAttribute("naturalWidth").Equals("0");
        }
    }
}
