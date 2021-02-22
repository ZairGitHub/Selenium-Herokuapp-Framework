using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public abstract class WebPage
    {
        protected IWebDriver Driver { get; }

        public WebPage(IWebDriver driver) => Driver = driver;
    }
}
