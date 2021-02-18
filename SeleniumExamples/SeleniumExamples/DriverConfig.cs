using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples
{
    public class DriverConfig
    {
        public DriverConfig(int elementWaitTime, int pageWaitTime)
        {
            ConfigureDriverTimeouts(elementWaitTime, pageWaitTime);
        }

        public FirefoxDriver Driver => new FirefoxDriver();

        private void ConfigureDriverTimeouts(int elementWaitTime, int pageWaitTime)
        {
            Driver.Manage().Timeouts().ImplicitWait = 
                TimeSpan.FromSeconds(elementWaitTime);

            Driver.Manage().Timeouts().PageLoad =
                TimeSpan.FromSeconds(pageWaitTime);
        }
    }
}
