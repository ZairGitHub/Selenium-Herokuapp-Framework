using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples
{
    public static class StaticDriver
    {
        //public static IWebDriver Driver = new ChromeDriver();

        public static IWebDriver Driver = new FirefoxDriver();
    }
}
