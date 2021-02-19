using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public class FormAuthenticationPage
    {
        private const string _validUsername = "tomsmith";
        private const string _validPassword = "SuperSecretPassword!";

        private readonly IWebDriver _driver;

        public FormAuthenticationPage(IWebDriver driver) => _driver = driver;

        private IWebElement ButtonLogin => _driver.FindElement(By.CssSelector(".fa"));

        private IWebElement ButtonLogOut => _driver.FindElement(By.CssSelector(".icon-2x"));

        private IWebElement FieldUsername => _driver.FindElement(By.Id("username"));
        
        private IWebElement FieldPassword => _driver.FindElement(By.Id("password"));

        private IWebElement TextUpdate => _driver.FindElement(By.Id("flash"));

        public string ReadUpdateText() => TextUpdate.Text;

        public void EnterUsername(string input) => FieldUsername.SendKeys(input);

        public void EnterPassword(string input) => FieldPassword.SendKeys(input);

        public void EnterValidUsername() => FieldUsername.SendKeys(_validUsername);

        public void EnterValidPassword() => FieldPassword.SendKeys(_validPassword);        

        public void ClickLoginButton() => ButtonLogin.Click();
    }
}
