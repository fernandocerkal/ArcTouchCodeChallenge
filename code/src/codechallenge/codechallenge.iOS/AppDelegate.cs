﻿using Foundation;
using UIKit;

namespace codechallenge.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Rg.Plugins.Popup.Popup.Init();
            Xamarin.Calabash.Start();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());


            return base.FinishedLaunching(app, options);
        }
    }
}