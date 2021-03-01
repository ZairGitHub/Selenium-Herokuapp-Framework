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

        private IWebElement ButtonUndo => Driver.FindElement(By.CssSelector(
                ".tox-toolbar__group:nth-child(1) > .tox-tbtn:nth-child(1)"));

        private IWebElement ButtonRedo => Driver.FindElement(By.CssSelector(
                ".tox-toolbar__group:nth-child(1) > .tox-tbtn:nth-child(2)"));

        public void EnterText(string text)
        {
            Driver.SwitchTo().Frame(0);
            TextParagraph.SendKeys(text);
        }

        public string ReadText() => TextParagraph.Text;

        public void ClickUndoButton()
        {
            Driver.SwitchTo().DefaultContent();
            ButtonUndo.Click();
            Driver.SwitchTo().Frame(0);
        }

        public void ClickRedoButton()
        {
            Driver.SwitchTo().DefaultContent();
            ButtonUndo.Click();
            Driver.SwitchTo().Frame(0);
        }

        public string ReadHighlightedText()
        {
            return ((IJavaScriptExecutor)Driver).ExecuteScript(
                "return window.getSelection().toString();") as string;
        }

        public void SelectAllText() => ButtonSelectAll.Click();
    }
}
