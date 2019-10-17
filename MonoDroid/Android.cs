using Android.App;
using Android.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono.Platform
{
    public class Android : IPlatform
    {
        public Android(Activity activity) { this.activity = activity; }
        public Activity activity { private set; get; }
        public static void Init(Activity activity)
        {
            Platform.Current = new Android(activity);
        }

        public void SetScene(YPScene scene)
        {
            //activity.SetContentView((View)scene.Services.GetService(typeof(View)));
        }        
    }
}
