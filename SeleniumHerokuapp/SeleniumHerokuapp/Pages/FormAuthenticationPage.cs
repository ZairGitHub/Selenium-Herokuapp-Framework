using OpenQA.Selenium;

namespace SeleniumHerokuApp.Pages
{
    public sealed class FormAuthenticationPage : WebPage, IPageNavigation
    {
        private const string _validUsername = "tomsmith";
        private const string _validPassword = "SuperSecretPassword!";

        public FormAuthenticationPage(IWebDriver driver) : base(driver)
        {
            SecureAreaPage = new SecureAreaPage(driver);
        }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.FormAuthetication);
        }

        public SecureAreaPage SecureAreaPage { get; private set; }

        private IWebElement ButtonLogin =>
            Driver.FindElement(By.CssSelector(".fa"));

        private IWebElement FieldUsername =>
            Driver.FindElement(By.Id("username"));
        
        private IWebElement FieldPassword =>
            Driver.FindElement(By.Id("password"));

        private IWebElement TextUpdate => Driver.FindElement(By.Id("flash"));

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
