using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumExamples.Pages
{
    public sealed class NestedFramesPage : WebPage, IPageNavigation
    {
        public NestedFramesPage(IWebDriver driver) : base(driver) { }

        public enum ParentFrame
        {
            Top,
            Bottom
        }

        public enum NestedFrame
        {
            Left,
            Middle,
            Right
        }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.NestedFrames);
        }

        private IWebElement FrameSet =>
            Driver.FindElement(By.CssSelector("frameset"));

        private IWebElement FrameTop =>
            Driver.FindElement(By.Name("frame-top"));

        private IWebElement FrameLeft =>
            Driver.FindElement(By.Name("frame-left"));

        private IWebElement FrameMiddle =>
            Driver.FindElement(By.Name("frame-middle"));

        private IWebElement FrameRight =>
            Driver.FindElement(By.Name("frame-right"));

        private IWebElement FrameBottom =>
            Driver.FindElement(By.Name("frame-bottom"));

        public void MoveBottomFrame(int pixels)
        {            
            new Actions(Driver).MoveToElement(FrameSet)
                .ClickAndHold()
                .MoveByOffset(0, pixels)
                .Perform();
        }

        public void SwitchToParentFrame(ParentFrame frame)
        {
            if (frame == ParentFrame.Top)
            {
                SwitchToFrame(FrameTop);
            }
            else if (frame == ParentFrame.Bottom)
            {
                SwitchToFrame(FrameBottom);
            }
        }

        public void SwitchToNestedFrame(NestedFrame frame)
        {
            if (frame == NestedFrame.Left)
            {
                SwitchToFrame(FrameLeft);
            }
            else if (frame == NestedFrame.Middle)
            {
                SwitchToFrame(FrameMiddle);
            }
            else if (frame == NestedFrame.Right)
            {
                SwitchToFrame(FrameRight);
            }
        }

        private void SwitchToFrame(IWebElement frame)
        {
            Driver.SwitchTo().Frame(frame);
        }
    }
}
