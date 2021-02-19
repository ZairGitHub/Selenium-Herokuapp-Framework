using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class FormAuthenticationPage
    {
        private readonly string _url = ConfigReader.Index + ConfigReader.FormAuthetication;
        private readonly IWebDriver _driver;

        public FormAuthenticationPage(IWebDriver driver) => _driver = driver;

        public void NavigateToPage() => _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");

        public void CloseDriver() => _driver.Quit();
    }
}
