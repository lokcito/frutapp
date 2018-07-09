
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
using Firebase;
using Firebase.Database;
using frutappi.Models;

namespace frutappi.Activities
{
    [Activity(Label = "LocationsActivity")]
    public class LocationsActivity : Activity
    {
        Button o;
        var userNamesRef;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_map);
            o = FindViewById<Button>(Resource.Id.button1);
            FirebaseApp.InitializeApp(this);
            FirebaseDatabase userNamesRef = new FirebaseDatabase.GetInstance("https://myxamarinproject-209715.firebaseio.com");

            o.Click += delegate {
                fireSync();
            };
            // Create your application here
        }
        public bool fireSync()
        {

            userNamesRef.Child("_root").AddValueEventListener(new MyValueEventListener());
            //var firebase = new FirebaseClient("aaa");
            //DataSnapshot o = userNamesRef.

            return false;
        }
        public class MyValueEventListener : Java.Lang.Object, Firebase.Database.IValueEventListener
        {

            public void OnCancelled(DatabaseError error)
            {
                System.Diagnostics.Debug.Print("<<");
            }

            public void OnDataChange(DataSnapshot snapshot)
            {
                System.Diagnostics.Debug.Print(">>");
                //throw new NotImplementedException();
            }

        }
    }
}
