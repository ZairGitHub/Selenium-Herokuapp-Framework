using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class FormAuthenticationPage
    {
        private const string _validUsername = "tomsmith";
        private const string _validPassword = "SuperSecretPassword!";

        private readonly string _url = ConfigReader.Index + ConfigReader.FormAuthetication;
        private readonly IWebDriver _driver;

        public FormAuthenticationPage(IWebDriver driver) => _driver = driver;

        public string UpdateText => TextUpdate.Text;

        public IWebElement ButtonLogin => _driver.FindElement(By.CssSelector(".fa"));

        public IWebElement ButtonLogOut => _driver.FindElement(By.CssSelector(".icon-2x"));

        public IWebElement FieldUsername => _driver.FindElement(By.Id("username"));
        
        public IWebElement FieldPassword => _driver.FindElement(By.Id("password"));

        private IWebElement TextUpdate => _driver.FindElement(By.Id("flash"));

        public void NavigateToPage() => _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");

        public void CloseDriver() => _driver.Quit();

        public void EnterUsername(string input) => FieldUsername.SendKeys(input);

        public void EnterPassword(string input) => FieldPassword.SendKeys(input);

        public void ClickLoginButton() => ButtonLogin.Click();
    }
}
