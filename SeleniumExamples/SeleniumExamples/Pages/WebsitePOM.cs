using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples.Pages
{
    public class WebsitePOM
    {
        public WebsitePOM(int elementWaitTime = 3, int pageWaitTime = 3)
        {
            DriverConfig = new DriverConfig(
                elementWaitTime, pageWaitTime).Driver;

            IndexPage = new IndexPage(new FirefoxDriver());
            AddRemovePage = new AddRemovePage(new FirefoxDriver());
        }

        public void Dispose() => DriverConfig.Quit();
        
        public FirefoxDriver DriverConfig { get; private set; }

        public IndexPage IndexPage { get; private set; }

        public AddRemovePage AddRemovePage { get; private set; }
    }
}
