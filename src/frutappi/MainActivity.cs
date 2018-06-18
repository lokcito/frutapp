using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;

using frutappi.Activities;
using frutappi.Models;

using frutappi.Helpers;

namespace frutappi
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        Button btnShowProducts;
        Button btnShowCalculator;
        Button btnInsert;
        Button btnUsers;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnShowProducts = FindViewById<Button>(Resource.Id.btnShowProducts);
            btnShowProducts.Click += showCatalog;
            btnShowCalculator = FindViewById<Button>(Resource.Id.btnCalculator);
            btnShowCalculator.Click += showCalculator;
            btnInsert = FindViewById<Button>(Resource.Id.btnInsert);
            btnInsert.Click += loadRow;
            btnUsers = FindViewById<Button>(Resource.Id.btnShowUsers);
            btnUsers.Click += showUsers;
        }
        private void showCatalog(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this, typeof(CatalogActivity));
            this.StartActivity(newActivity);
        }
        private void showUsers(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this, typeof(UsersActivity));
            this.StartActivity(newActivity);
        }
        private void showCalculator(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this, typeof(CalculatorActivity));
            this.StartActivity(newActivity);
        }
        private void loadRow(object sender, EventArgs args)
        {
            Product o = new Product();
            o.id = 1;
            o.name = "kkk";
            o.description = "jkjjkjkjkjk";
            if (DatabaseHelper.insert(ref o, DatabaseHelper.locate(Settings.DATABASE_PATH)))
            {
                Toast.MakeText(this, "Registro insertado correctamente.", ToastLength.Short).Show();
            } else
            {
                Toast.MakeText(this, "Registro insertado fallido.", ToastLength.Short).Show();
            }

        }
    }
}

