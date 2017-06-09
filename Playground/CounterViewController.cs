using UIKit;

namespace Playground
{
    public class CounterViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            EdgesForExtendedLayout = UIRectEdge.None;
            View.BackgroundColor = UIColor.Blue;
        }
    }
}
