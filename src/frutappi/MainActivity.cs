using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using frutappi.Activities;
using Android.Content;

namespace frutappi
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnShowProducts;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnShowProducts = FindViewById<Button>(Resource.Id.btnShowProducts);
            btnShowProducts.Click += showCatalog;
        }
        private void showCatalog(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this, typeof(CatalogActivity));
            this.StartActivity(newActivity);
        }
    }
}

