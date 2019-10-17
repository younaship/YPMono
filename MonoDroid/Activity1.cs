using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace MonoDroid
{
    [Activity(Label = "MonoDroid"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.FullUser
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize | ConfigChanges.ScreenLayout)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            YPMono.Platform.Android.Init(this);
            // var g = new Game1();
            // var g = new MonoShared.Game1();
            var g = new YPMono.YPGame(new MonoShared.Sence1());
            SetContentView((View)g.Services.GetService(typeof(View)));
            g.Run();     
        }
    }
}

