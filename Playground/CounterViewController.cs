using UIKit;
using CoreGraphics;
using Playground.Common;
using Reactive.Bindings;
using System.Reactive.Linq;
using System;

namespace Playground
{
    public class CounterViewController : UIViewController
    {
        readonly UILabel counterLabel = new UILabel();
        readonly UIButton incrementButton = new UIButton();
        readonly UIButton decrementButton = new UIButton();
        readonly UIButton resetButton = new UIButton();

        CounterViewModel viewModel { get; } = new CounterViewModel();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            EdgesForExtendedLayout = UIRectEdge.None;
            View.BackgroundColor = UIColor.GroupTableViewBackgroundColor;
            SetAppearance();
            Bind();
            View.AddSubviews(new UIView[] { counterLabel, incrementButton, decrementButton, resetButton });
        }

        void SetAppearance()
        {
            counterLabel.TextAlignment = UITextAlignment.Center;
            counterLabel.Font = UIFont.BoldSystemFontOfSize(40);
            incrementButton.SetTitle("+", UIControlState.Normal);
            incrementButton.BackgroundColor = UIColor.Red;
            decrementButton.SetTitle("-", UIControlState.Normal);
            decrementButton.BackgroundColor = UIColor.Blue;
            resetButton.SetTitle("0", UIControlState.Normal);
            resetButton.BackgroundColor = UIColor.Gray;
        }

        void Bind()
        {
            viewModel.Title.Subscribe(x => NavigationItem.Title = x);
            counterLabel.SetBinding(x => x.Text, viewModel.CounterValue);
            incrementButton.TouchUpInside += (sender, e) => viewModel.Increment.Execute();
            decrementButton.TouchUpInside += (sender, e) => viewModel.Decrement.Execute();
            resetButton.TouchUpInside += (sender, e) => viewModel.Reset.Execute();
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
