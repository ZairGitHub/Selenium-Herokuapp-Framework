using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumExamples.Pages
{
    public sealed class NestedFramesPage : WebPage, IPageNavigation
    {
        public NestedFramesPage(IWebDriver driver) : base(driver) { }

        public enum Frame
        {
            Top,
            Left,
            Middle,
            Right,
            Bottom
        }

        private enum ParentFrame
        {
            Top,
            Bottom
        }

        private enum NestedFrame
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

        public void SwitchToFrame(Frame frame)
        {
            SwitchToDefaultFrame();
            switch (frame)
            {
                case Frame.Top:
                    SwitchToParentFrame(ParentFrame.Top);
                    break;
                case Frame.Left:
                    SwitchToNestedFrame(NestedFrame.Left);
                    break;
                case Frame.Middle:
                    SwitchToNestedFrame(NestedFrame.Middle);
                    break;
                case Frame.Right:
                    SwitchToNestedFrame(NestedFrame.Right);
                    break;
                case Frame.Bottom:
                    SwitchToParentFrame(ParentFrame.Bottom);
                    break;
            }
        }

        private void SwitchToParentFrame(ParentFrame frame)
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

        private void SwitchToNestedFrame(NestedFrame frame)
        {
            SwitchToFrame(FrameTop);
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

        public int ReadParentFrameSize()
        {
            SwitchToDefaultFrame();
            return FrameTop.Size.Height;
        }

        public int ReadNestedFrameSize()
        {
            SwitchToDefaultFrame();
            SwitchToFrame(FrameTop);
            return FrameMiddle.Size.Width;
        }

        public void ResizeTopAndBottomFrames(int pixelOffset)
        {
            SwitchToDefaultFrame();
            new Actions(Driver).MoveToElement(FrameSet)
                .ClickAndHold()
                .MoveByOffset(0, pixelOffset)
                .Perform();
        }

        public void ResizeLeftAndMiddleFrames(int pixelOffset)
        {
            SwitchToDefaultFrame();
            SwitchToFrame(FrameTop);
            IWebElement frame = FrameMiddle;
            new Actions(Driver)
                    .MoveToElement(frame, frame.Size.Width, 0)
                    .ClickAndHold()
                    .MoveByOffset(pixelOffset, 0)
                    .Perform();
        }

        public void ResizeRightAndMiddleFrames(int pixels)
        {
            SwitchToDefaultFrame();
            SwitchToFrame(FrameTop);
            IWebElement frame = FrameMiddle;
            new Actions(Driver)
                .MoveToElement(frame, frame.Size.Width, 0)
                .ClickAndHold()
                .MoveByOffset(pixels, 0)
                .Perform();
        }

        private void SwitchToFrame(IWebElement frame)
        {
            Driver.SwitchTo().Frame(frame);
        }

        private void SwitchToDefaultFrame() => Driver.SwitchTo().DefaultContent();
    }
}
