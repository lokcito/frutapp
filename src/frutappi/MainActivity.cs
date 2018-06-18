using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;

using frutappi.Activities;
using frutappi.Models;

using frutappi.Helpers;
using frutappi.Presenters;

namespace frutappi
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        Button btnShowProducts;
        Button btnShowCalculator;
        Button btnInsert;
        Button btnUsers;
        Button btnMap;
        MainPresenter presenter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            presenter = new MainPresenter(this);
            btnShowProducts = FindViewById<Button>(Resource.Id.btnShowProducts);
            btnShowProducts.Click += presenter.showCatalog;
            btnShowCalculator = FindViewById<Button>(Resource.Id.btnCalculator);
            btnShowCalculator.Click += presenter.showCalculator;
            btnInsert = FindViewById<Button>(Resource.Id.btnInsert);
            btnInsert.Click += loadRow;
            btnUsers = FindViewById<Button>(Resource.Id.btnShowUsers);
            btnUsers.Click += presenter.showUsers;
            btnMap = FindViewById<Button>(Resource.Id.btnShowMap);
            btnMap.Click += presenter.showLocations;
        }


        protected void loadRow(object sender, EventArgs args)
        {
            if(presenter.loadRow(sender, args)) {
                Toast.MakeText(this, "Registro insertado correctamente.", ToastLength.Short).Show();
            } else {
                Toast.MakeText(this, "Registro insertado fallido.", ToastLength.Short).Show();
            }

        }
    }
}

