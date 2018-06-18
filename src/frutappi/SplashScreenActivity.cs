using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;


namespace frutappi
{
    [Activity(Label = "Frutapp", Icon = "@mipmap/icecream", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }
        // Tarea que despliega el mainactivity
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Desabilitamos que el usuario vuelva atraz
        public override void OnBackPressed() { }

        // Espera 8 segundos
        async void SimulateStartup()
        {
            //Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
            await Task.Delay(1000);
            //Log.Debug(TAG, "Startup work is finished - starting MainActivity.");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}

 //- Start Android Studio
 //- Select menu "Tools > Android > SDK Manager"
 //- Click "SDK Tools" tab
 //- Check "Android Emulator" checkbox
 //- Click "OK"