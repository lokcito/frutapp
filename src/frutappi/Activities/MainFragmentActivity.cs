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
using frutappi.Fragments;

namespace frutappi.Activities
{
    [Activity(Label = "MainFragmentActivity")]
    public class MainFragmentActivity : Activity
    {
        bool showingTwoFragments;
        Button btnOne;
        Button btnTwo;
        FrameLayout playQuoteFragment;
        FragmentTransaction ft;
        private void showTwo(object sender, EventArgs args)
        {
            var quoteFrag = new FragmentTwo();

            FragmentTransaction ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.fragmentMany, quoteFrag);
            ft.AddToBackStack(null);
            ft.SetTransition(FragmentTransit.FragmentFade);
            ft.Commit();
        }
        private void showOne(object sender, EventArgs args)
        {
            var quoteFrag = new FragmentOne();

            ft.Replace(Resource.Id.fragmentMany, quoteFrag);
            ft.AddToBackStack(null);
            ft.SetTransition(FragmentTransit.FragmentFade);
            ft.Commit();
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main_fragment);
            playQuoteFragment = FindViewById<FrameLayout>(Resource.Id.fragmentMany);
            btnOne = FindViewById<Button>(Resource.Id.button1);
            btnTwo = FindViewById<Button>(Resource.Id.button2);
            btnOne.Click += showOne;
            btnTwo.Click += showTwo;
            ft = FragmentManager.BeginTransaction();

        }
    }
}