using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples
{
    public static class StaticDriver
    {
        //public static Type Type = typeof(ChromeDriver);

        public static Type Type => typeof(FirefoxDriver);
    }
}
