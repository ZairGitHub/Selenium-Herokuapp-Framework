using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class BrokenImagesPage : WebPage, IPageNavigation
    {
        public BrokenImagesPage(IWebDriver driver) : base(driver) { }

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

        public bool IsImageBroken(int id)
        {
            IWebElement image = null;
            if (id == 1)
            {
                image = Image1;
            }
            else if (id == 2)
            {
                image = Image2;
            }
            else if (id == 3)
            {
                image = Image3;
            }
            return image.GetAttribute("naturalWidth").Equals("0");
        }
    }
}
