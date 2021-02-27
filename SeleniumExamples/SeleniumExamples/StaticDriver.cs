using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples
{
    public static class StaticDriver
    {
        private static readonly Type _chrome = typeof(ChromeDriver);

        private static readonly Type _firefox = typeof(FirefoxDriver);

        public static readonly Type Type = _chrome;
    }
}
