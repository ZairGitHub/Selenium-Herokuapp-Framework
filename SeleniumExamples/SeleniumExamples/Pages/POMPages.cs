using System;
using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class POMPages<driver> : IDisposable where driver : IWebDriver, new()
    {
        public POMPages(int elementWaitTime = 5, int pageWaitTime = 5)
        {
            DriverConfig = new DriverConfig<driver>(
                elementWaitTime, pageWaitTime).Driver;

            AddRemovePage = new AddRemovePage(DriverConfig);
        }

        public void Dispose() => DriverConfig.Quit();
        
        public driver DriverConfig { get; private set; }

        public AddRemovePage AddRemovePage { get; private set; }

     
    }
}
