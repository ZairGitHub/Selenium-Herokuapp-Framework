using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples
{
    public class DriverConfig
    {
        private readonly FirefoxOptions _options = new FirefoxOptions();

        public DriverConfig(int elementWaitTime, int pageWaitTime)
        {
            _options = new FirefoxOptions();
            _options.AddArguments("--headless");
            Driver = new FirefoxDriver(_options);

            ConfigureDriverTimeouts(elementWaitTime, pageWaitTime);
            
        }

        public FirefoxDriver Driver { get; }

        private void ConfigureDriverTimeouts(int elementWaitTime, int pageWaitTime)
        {
            Driver.Manage().Timeouts().ImplicitWait = 
                TimeSpan.FromSeconds(elementWaitTime);

            Driver.Manage().Timeouts().PageLoad =
                TimeSpan.FromSeconds(pageWaitTime);
        }
    }
}
