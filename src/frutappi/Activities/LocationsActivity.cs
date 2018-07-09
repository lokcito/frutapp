
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
using frutappi.Models;

namespace frutappi.Activities
{
    [Activity(Label = "LocationsActivity")]
    public class LocationsActivity : Activity
    {
        Button o;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_map);
            o = FindViewById<Button>(Resource.Id.button1);
            o.Click += delegate {
                Product.fireSync();
            };
            // Create your application here
        }
    }
}
