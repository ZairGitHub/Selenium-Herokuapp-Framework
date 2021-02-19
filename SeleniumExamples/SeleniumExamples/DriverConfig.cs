using System;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples
{
    public class DriverConfig
    {
        public DriverConfig(bool isHeadless, int elementWaitTime, int pageWaitTime)
        {
            /*if (isHeadless)
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArguments("--headless");
                Driver = new FirefoxDriver(options);
            }
            else
            {
                Driver = new FirefoxDriver();
            }*/
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
