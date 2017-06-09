using Foundation;
using UIKit;

namespace Playground
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override void FinishedLaunching(UIApplication application)
        {
            var navigationController = new UINavigationController(new CounterViewController());
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = navigationController;
            Window.MakeKeyAndVisible();
        }
    }
}

