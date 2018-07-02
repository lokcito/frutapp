
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Widget;

//icons --> https://material.io/tools/icons/?icon=home&style=baseline

namespace frutappi.Activities
{
    [Activity(Label = "TabActivity", Theme = "@style/AppTheme")]
    public class TabActivity : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private TextView _textMessage;
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    _textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.navigation_dashboard:
                    _textMessage.SetText(Resource.String.title_dashboard);
                    return true;
                case Resource.Id.navigation_notifications:
                    _textMessage.SetText(Resource.String.title_notifications);
                    return true;
            }
            return false;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_tab);

            // Create your application here
            _textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
    }
}