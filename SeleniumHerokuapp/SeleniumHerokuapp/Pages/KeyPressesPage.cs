﻿using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class KeyPressesPage : WebPage, IPageNavigation
    {
        public KeyPressesPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.KeyPresses);
        }

        private IWebElement Input => Driver.FindElement(By.Id("target"));

        private IWebElement TextUpdate => Driver.FindElement(By.Id("result"));

        public string ReadInformation() => TextUpdate.Text;
        
        public void PressTabKey() => Input.SendKeys(Keys.Tab);

        public void PressEnterKey() => Input.SendKeys(Keys.Enter);

        public void PressEscapeKey() => Input.SendKeys(Keys.Escape);
    }
}
