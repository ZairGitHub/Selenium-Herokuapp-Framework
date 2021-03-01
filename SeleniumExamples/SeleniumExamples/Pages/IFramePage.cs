using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class IFramePage : WebPage, IPageNavigation
    {
        public IFramePage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.IFrame);
        }

        private IWebElement TextParagraph =>
            Driver.FindElement(By.CssSelector("p"));

        private IWebElement ButtonSelectAll =>
            Driver.FindElement(By.CssSelector(".tox-statusbar__path-item"));

        public void EnterText(string text)
        {
            Driver.SwitchTo().Frame(0);
            TextParagraph.SendKeys(text);
        }

        public string ReadText() => TextParagraph.Text;

        public string ReadHighlightedText()
        {
            return ((IJavaScriptExecutor)Driver).ExecuteScript(
                "return window.getSelection().toString();") as string;
        }

        public void SelectAllText() => ButtonSelectAll.Click();
    }
}
