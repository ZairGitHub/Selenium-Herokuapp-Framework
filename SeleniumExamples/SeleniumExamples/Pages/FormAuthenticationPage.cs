using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class FormAuthenticationPage : WebPage, IPageNavigation
    {
        private const string _validUsername = "tomsmith";
        private const string _validPassword = "SuperSecretPassword!";

        public FormAuthenticationPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.FormAuthetication);
        }

        private IWebElement ButtonLogin =>
            Driver.FindElement(By.CssSelector(".fa"));

        private IWebElement FieldUsername =>
            Driver.FindElement(By.Id("username"));
        
        private IWebElement FieldPassword =>
            Driver.FindElement(By.Id("password"));

        private IWebElement TextUpdate => Driver.FindElement(By.Id("flash"));

        public void EnterUsername(string input) => FieldUsername.SendKeys(input);

        public void EnterPassword(string input) => FieldPassword.SendKeys(input);

        public void EnterValidUsername() => FieldUsername.SendKeys(_validUsername);

        public void EnterValidPassword() => FieldPassword.SendKeys(_validPassword);

        public void ClickLoginButton() => ButtonLogin.Click();

        public void LogInAsAuthenticatedUser()
        {
            EnterValidUsername();
            EnterValidPassword();
            ClickLoginButton();
        }

        public string ReadUpdateText() => TextUpdate.Text;
    }
}
