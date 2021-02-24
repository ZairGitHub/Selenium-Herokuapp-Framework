using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples
{
    public class DriverConfig<T> where T : IWebDriver, new()
    {
        private readonly int _elementWaitTime;
        private readonly int _pageWaitTime;
        private readonly FirefoxOptions _options;

        public DriverConfig(
            bool isHeadless, int elementWaitTime, int pageWaitTime)
        {
            if (isHeadless)
            {
                if (typeof(T) == typeof(FirefoxDriver))
                {
                    _options = new FirefoxOptions();
                    _options.AddArguments("--headless");
                    Driver = new FirefoxDriver(_options);
                }
            }
            else
            {
                Driver = new T();
            }
            _elementWaitTime = elementWaitTime;
            _pageWaitTime = pageWaitTime;
            ConfigureDriverTimeouts();
        }

        public IWebDriver Driver { get; set; }

        private void ConfigureDriverTimeouts()
        {
            if (_elementWaitTime > 0)
            {
                Driver.Manage().Timeouts().ImplicitWait =
                    TimeSpan.FromSeconds(_elementWaitTime);
            }

            if (_pageWaitTime > -1)
            {
                Driver.Manage().Timeouts().PageLoad =
                    TimeSpan.FromSeconds(_pageWaitTime);
            }
        }
    }
}
