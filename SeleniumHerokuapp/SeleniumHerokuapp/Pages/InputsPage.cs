﻿using OpenQA.Selenium;

namespace SeleniumHerokuapp.Pages
{
    public sealed class InputsPage : WebPage, IPageNavigation
    {
        public InputsPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Inputs);
        }

        private IWebElement Input => Driver.FindElement(By.CssSelector("input"));

        public double ReadValue() => double.Parse(Input.GetAttribute("value"));
        
        public void EnterValue(double value) => Input.SendKeys(value.ToString());
        
        public void IncrementValue() => Input.SendKeys(Keys.Up);

        public void DecrementValue() => Input.SendKeys(Keys.Down);
    }
}
