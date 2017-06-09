using UIKit;
using CoreGraphics;

namespace Playground
{
    public class CounterViewController : UIViewController
    {
        readonly UILabel counterLabel = new UILabel();
        readonly UIButton incrementButton = new UIButton();
        readonly UIButton decrementButton = new UIButton();
        readonly UIButton resetButton = new UIButton();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            EdgesForExtendedLayout = UIRectEdge.None;
            View.BackgroundColor = UIColor.GroupTableViewBackgroundColor;
            counterLabel.Text = "0";
            counterLabel.TextAlignment = UITextAlignment.Center;
            counterLabel.Font = UIFont.BoldSystemFontOfSize(40);
            incrementButton.SetTitle("+", UIControlState.Normal);
            incrementButton.BackgroundColor = UIColor.Red;
            decrementButton.SetTitle("-", UIControlState.Normal);
            decrementButton.BackgroundColor = UIColor.Blue;
            resetButton.SetTitle("0", UIControlState.Normal);
            resetButton.BackgroundColor = UIColor.Gray;
            View.AddSubviews(new UIView[] { counterLabel, incrementButton, decrementButton, resetButton });
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            var labelSize = 100;
            var buttonSize = 40;
            var margin = 12;
            var width = View.Frame.Width;
            counterLabel.Frame = new CGRect((width - labelSize) / 2, margin, labelSize, labelSize);

            var buttonYOrigin = margin + labelSize + margin;
            incrementButton.Frame = new CGRect((width - buttonSize) / 2 - buttonSize - margin, buttonYOrigin, buttonSize, buttonSize);
            decrementButton.Frame = new CGRect((width - buttonSize) / 2, buttonYOrigin, buttonSize, buttonSize);
            resetButton.Frame = new CGRect((width - buttonSize) / 2 + buttonSize + margin, buttonYOrigin, buttonSize, buttonSize);
        }
    }
}
