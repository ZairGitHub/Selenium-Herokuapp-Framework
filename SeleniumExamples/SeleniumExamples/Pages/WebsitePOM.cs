using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples.Pages
{
    public class WebsitePOM
    {
        public WebsitePOM(int elementWaitTime = 0, int pageWaitTime = 0)
        {
            Driver = new DriverConfig(
                elementWaitTime, pageWaitTime).Driver;

            IndexPage = new IndexPage(Driver);
            AddRemovePage = new AddRemovePage(Driver);
        }
        
        public FirefoxDriver Driver { get; private set; }

        public IndexPage IndexPage { get; private set; }

        public AddRemovePage AddRemovePage { get; private set; }

        public void NavigateToPage(string url) => Driver.Navigate().GoToUrl(url);

        public void NavigateToIndexPage()
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index);
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
        }

        public void CloseDriver() => Driver.Quit();
    }
}
